using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;
using Microsoft.Office.Interop.Word;
using System.Drawing;

namespace WebApiPixel.AppServices.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async void UploadDoc(IFormFile data, string dirname, string filename)
        {
            // загрузка файла на диск
            if (!Directory.Exists($"F:\\WebApiPixel\\Files\\{dirname}"))
            {
                Directory.CreateDirectory($"F:\\WebApiPixel\\Files\\{dirname}");
            }
            //await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            using (FileStream fs = File.Create($"F:\\WebApiPixel\\Files\\{dirname}\\{filename}"))
            {
                await data.CopyToAsync(fs);
            }
        }

        public bool Upload(IFormFile data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            var filename = data.FileName;
            var fileNameWithoutExtension = filename.Split('.')[0];
            if (File.Exists($"F:\\WebApiPixel\\Files\\{fileNameWithoutExtension}\\{data.FileName}"))
            {
                filename = filename.Split('.')[0] + "_" + Guid.NewGuid().ToString().Split('-')[0] + "." + filename.Split('.')[1];
                fileNameWithoutExtension = filename.Split('.')[0];
            }
            UploadDoc(data, fileNameWithoutExtension, filename);
            //File.WriteAllText("F:\\WebApiPixel\\Files\\text.txt", data.FileName.Split('.')[0]);
            WordToPdf(filename);
            //var fileName = data.FileName.Split('.')[0];
            PdfToPng(fileNameWithoutExtension);
            while (!File.Exists(@$"F:\WebApiPixel\Files\{fileNameWithoutExtension}\" + fileNameWithoutExtension + ".png")) continue;
            Thread.Sleep(2000);
            CheckWarnings(fileNameWithoutExtension);

            //await data.CopyToAsync(fileStream);
            /*
            // загрузка файла в БД
            var file = new Files
            {
                Name = data.Name,
                FileName = data.FileName,
                ContentType = data.ContentType,
                ContentDisposition = data.ContentDisposition,
                Length = data.Length,
            };

            // считываем переданный файл в массив байтов
            using var binReader = new BinaryReader(data.OpenReadStream());
            file.Content = binReader.ReadBytes((int)data.Length);

            await _fileRepository.SaveFile(file);*/

            return CheckWarnings(data.FileName);
        }

        public void WordToPdf(string fileName)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object oMissing = System.Reflection.Missing.Value;

            DirectoryInfo dirInfo = new DirectoryInfo($"F:\\WebApiPixel\\Files\\{fileName.Split('.')[0]}");
            FileInfo[] wordFiles = dirInfo.GetFiles(fileName);

            word.Visible = false;
            word.ScreenUpdating = false;

            foreach (FileInfo wordFile in wordFiles)
            {
                Object filename = (Object)wordFile.FullName;
                Document doc = word.Documents.Open(ref filename, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                if (doc.PageSetup.LeftMargin == 0 || doc.PageSetup.TopMargin == 0)
                {
                    doc.PageSetup.LeftMargin = 19f;
                    doc.PageSetup.TopMargin = 19f;
                    doc.PageSetup.RightMargin = 15f;
                    doc.PageSetup.BottomMargin = 19f;
                }
                doc.Select();
                doc.Activate();

                object outputFileName = wordFile.FullName.Replace(".docx", ".pdf");
                object fileFormat = WdSaveFormat.wdFormatPDF;

                doc.SaveAs(ref outputFileName,
                ref fileFormat, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
                doc = null;

                ((_Application)word).Quit(ref oMissing, ref oMissing, ref oMissing);
                word = null;
            }

        }

        public void PdfToPng(string fileName)
        {
            //string pdfFilePath = @"F:\WebApiPixel\Files\" + fileName;
            string pdfFilePath = @$"F:\WebApiPixel\Files\{fileName}\" + fileName + ".pdf";

            //string outputPng = @"F:\WebApiPixel\Files\" + fileName + ".png";
            string outputPng = @$"F:\WebApiPixel\Files\{fileName}\" + fileName + ".png";

            try
            {
                byte[] croppedPDF = File.ReadAllBytes(pdfFilePath);
                string gsPath = @"C:\Program Files\gs\gs9.56.1\bin\gswin64c.exe";

                List<string> gsArgsList = new List<string>();
                gsArgsList.Add(" -q -dNOPAUSE -dBATCH -sDEVICE=pnggray -g2550x3300 -dPDFFitPage -dUseCropBox");
                gsArgsList.Add(" -sOutputFile=" + outputPng + " " + pdfFilePath);
                var gsArgs = String.Join(null, gsArgsList);

                string gs = gsPath + gsArgs;
                System.Diagnostics.Process.Start(gsPath, gsArgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        public bool CheckWarnings(string fileName)
        {
            char[] ascii = { '2', '1', '0' };
            //File.WriteAllText("F:\\WebApiPixel\\Files\\text.txt", @"F:\WebApiPixel\Files\" + fileName.Split('.')[0] + ".png");
            //var bitmap = new Bitmap(@"F:\WebApiPixel\Files\" + fileName + ".png");
            var bitmap = new Bitmap(@$"F:\WebApiPixel\Files\{fileName.Split('.')[0]}\" + fileName.Split('.')[0] + ".png");
            bitmap = ResizeBitmap(bitmap);
            bitmap = ToGrayscale(bitmap);
            var rows = Convert(bitmap, ascii);
            bitmap.Dispose();
            List<string> res = new List<string>();

            foreach (var row in rows)
            {
                string str = "";
                for (int i = 0; i < row.Length; i++)
                {
                    str += row[i];
                }
                if (str.Contains("22222222222222")) res.Add(str);
                else
                {
                    str = str.Replace('1', '0');
                    str = str.Replace('2', '0');
                    res.Add(str);
                }
            }

            int countBlackColor = 0;
            foreach (var row in res)
            {
                foreach (var item in row)
                    if (item == '2') countBlackColor++;
            }
            
            return isBadDoc(res);
        }

        public bool isBadDoc(List<string> picture)
        {
            int countSpacing = 0;
            int widthTwo = 0;
            int index = 0;
            bool firstFigureFinded = false;

            foreach (var row in picture)
            {
                if (row.Contains("2") && !firstFigureFinded) firstFigureFinded = true;
                if (firstFigureFinded && !row.Contains("2") && !row.Contains("1"))
                {
                    countSpacing++;
                    if (widthTwo == 0) widthTwo = picture[index - 1].LastIndexOf('2');
                };
                string tmp = row.Substring(0, widthTwo);
                if (tmp.Contains("2") && firstFigureFinded && countSpacing != 0) return true;
                index++;
            }
            return false;
        }

        public static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var maxWidth = 350;
            var newHeight = bitmap.Height / 1.5 * maxWidth / bitmap.Width;
            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));
            return bitmap;
        }

        public static Bitmap ToGrayscale(Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, avg, avg, avg));
                }
            }
            return bitmap;
        }

        public char[][] Convert(Bitmap bitmap, char[] ascii)
        {
            var result = new char[bitmap.Height][];

            for (int i = 0; i < bitmap.Height; i++)
            {
                result[i] = new char[bitmap.Width];
                for (int j = 0; j < bitmap.Width; j++)
                {
                    int mapIndex = (int)Map(bitmap.GetPixel(j, i).R, 0, 255, 0, ascii.Length - 1);
                    result[i][j] = ascii[mapIndex];
                }
            }

            return result;
        }

        public float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
        {
            return ((valueToMap - start1) / (stop1 - start1) * (stop2 - start2) + start2);
        }
    }
}

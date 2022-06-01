using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Загрузка файла на сервер
        /// </summary>
        /// <param name="data">файл</param>
        /// <returns>Успех/неудачу добавления</returns>
        bool Upload(IFormFile data);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    public class Files : EntityBase
    {
        public string ContentType { get; set; }

        public string ContentDisposition { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    public class OfferMainPage : EntityBase
    {
        /// <summary>
        /// Название услуги
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Имя картинки
        /// </summary>
        public string FileName { get; set; }
    }
}

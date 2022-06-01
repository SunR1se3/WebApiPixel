using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    /// <summary>
    /// Параметры для тиража документов
    /// </summary>
    public class DocumentSettings : EntityBase
    {
        /// <summary>
        /// Название параметра
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Id товара, к которому относится параметр
        /// </summary>
        public Guid WareId { get; set; }

        public virtual Ware Ware { get; set; }
    }
}

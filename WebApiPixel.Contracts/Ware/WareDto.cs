using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.Contracts.Ware
{
    /// <summary>
    /// Модель представления товара
    /// </summary>
    public class WareDto : DtoBase
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Детали товара (тип бумаги, материал...)
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// id категории, к которой относится товар
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public string CategoryName { get; set; }
    }
}

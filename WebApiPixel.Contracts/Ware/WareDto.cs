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
        /// Описание услуги
        /// </summary>
        public string Description { get; set; }

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

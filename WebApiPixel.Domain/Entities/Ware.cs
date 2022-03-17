using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Ware : EntityBase
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
        /// id категории, к которой относится товар
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Заказ
        /// </summary>
        public virtual Order Order { get; set; }
    }
}

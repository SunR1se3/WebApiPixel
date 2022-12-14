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
        public virtual Category Category { get; set; }

        /// <summary>
        /// Коллекция заказов
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Коллекция настроек
        /// </summary>
        public virtual ICollection<DocumentSettings> DocumentSettings { get; set; }
    }
}

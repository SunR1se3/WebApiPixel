using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    public class Category : EntityBase
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Доступность категории для пользователя
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Коллекция товаров
        /// </summary>
        public virtual ICollection<Ware> Wares { get; set; }

        /// <summary>
        /// Заказ
        /// </summary>
        //public virtual Order Order { get; set; }
    }
}

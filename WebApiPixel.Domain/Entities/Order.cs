using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order : EntityBase
    {
        /// <summary>
        /// Фио клиента
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Статус принятия заказа (true, false)
        /// </summary>
        public bool IsAccepted { get; set; }

        /// <summary>
        /// id категории
        /// </summary>
        //public Guid CategoryId { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        //public virtual Category Category { get; set; }

        /// <summary>
        /// id товара
        /// </summary>
        public Guid WareId { get; set; }
        
        /// <summary>
        /// Товар
        /// </summary>
        public virtual Ware Ware { get; set; }
    }
}

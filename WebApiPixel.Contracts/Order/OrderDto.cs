using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.Contracts.Order
{
    /// <summary>
    /// Модель представления заказа
    /// </summary>
    public class OrderDto : DtoBase
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
        /// Товар
        /// </summary>
        public string WareName { get; set; }

        /// <summary>
        /// id товара
        /// </summary>
        public Guid WareId { get; set; }
    }
}

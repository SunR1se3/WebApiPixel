using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    /// <summary>
    /// Хронология заказа
    /// </summary>
    public class OrderHronology : EntityBase
    {
        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime DateCreationOrder { get; set; }

        /// <summary>
        /// Дата принятия заказа
        /// </summary>
        public DateTime DateAcceptionOrder { get; set; }

        /// <summary>
        /// Дата подготовки к выполнению
        /// </summary>
        public DateTime DatePrepare { get; set; }

        /// <summary>
        /// Дата начала выполнения
        /// </summary>
        public DateTime DateProduce { get; set; }

        /// <summary>
        /// Дата окончания работы
        /// </summary>
        public DateTime DateOrderIsReady { get; set; }

        /// <summary>
        /// id заказа
        /// </summary>
        public Guid IdOrder { get; set; }

        /// <summary>
        /// Заказ
        /// </summary>
        public virtual Order Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.Contracts.OrderHronology
{
    /// <summary>
    /// Модель представления хронологии заказа
    /// </summary>
    public class OrderHronologyDto : DtoBase
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
        /// Изготовление заказа
        /// </summary>
        public bool Production { get; set; }

        /// <summary>
        /// Заказ готов
        /// </summary>
        public bool isDone { get; set; }

        /*/// <summary>
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
        public DateTime DateOrderIsReady { get; set; }*/

        /// <summary>
        /// id заказа
        /// </summary>
        public Guid IdOrder { get; set; }
    }
}

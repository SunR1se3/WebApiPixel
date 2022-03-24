using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    /// <summary>
    /// СотрудникЗаказ
    /// </summary>
    public class EmployeeOrder : EntityBase
    {
        /// <summary>
        /// id сотрудника
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// id заказа
        /// </summary>
        public Guid OrderId { get; set; }
    }
}

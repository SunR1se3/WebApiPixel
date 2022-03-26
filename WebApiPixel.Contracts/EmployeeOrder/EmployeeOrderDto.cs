using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.Contracts.EmployeeOrderDto
{
    public class EmployeeOrderDto : DtoBase
    {
        /// <summary>
        /// id сотрудника
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// id заказа
        /// </summary>
        public Guid OrderId { get; set; }
    }
}

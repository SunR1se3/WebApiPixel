using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.Contracts.Employee
{
    /// <summary>
    /// Модель представления сотрудника
    /// </summary>
    public class EmployeeDto : DtoBase
    {
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
    }
}

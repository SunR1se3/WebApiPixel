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

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Является ли сотрудник админом
        /// </summary>
        public bool isAdmin { get; set; }
    }
}

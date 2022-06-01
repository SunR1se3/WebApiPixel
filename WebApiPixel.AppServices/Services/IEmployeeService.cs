using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Employee;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с сотрудниками
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        ///  Получает список всех сотрудников
        /// </summary>
        /// <returns>Список всех сотрудников</returns>
        Task<List<EmployeeDto>> GetEmployees();

        /// <summary>
        /// Вход в аккаукнт
        /// </summary>
        /// <param name="login">Логин сотрудника</param>
        /// <param name="password">Пароль сотрудника</param>
        /// <returns></returns>
        Task<List<EmployeeDto>> Login(string login, string password);

        /// <summary>
        /// Добавляет сотрудника
        /// </summary>
        /// <param name="model">Модель сотрудника</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(EmployeeDto model);

        /// <summary>
        /// Удаляет сотрудника
        /// </summary>
        /// <param name="id">id сотрудника</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущего сотрудника
        /// </summary>
        /// <param name="model">Модель сотрудника</param>
        /// <returns>Обновленную модель</returns>
        Task<EmployeeDto> UpdateAsync(EmployeeDto model);
    }
}

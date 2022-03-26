using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.EmployeeOrderDto;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с СотрудникЗаказ
    /// </summary>
    public interface IEmployeeOrderService
    {
        /// <summary>
        ///  Получает список всех записей
        /// </summary>
        /// <returns>Список всех записей</returns>
        Task<List<EmployeeOrderDto>> GetEmployeeOrders();

        /// <summary>
        /// Добавляет запись
        /// </summary>
        /// <param name="model">Модель СотрудникЗаказ</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(EmployeeOrderDto model);

        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущую
        /// </summary>
        /// <param name="model">Модель СотрудникЗаказ</param>
        /// <returns>Обновленную модель</returns>
        Task<EmployeeOrderDto> UpdateAsync(EmployeeOrderDto model);
    }
}

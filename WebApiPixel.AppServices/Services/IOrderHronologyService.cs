using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.OrderHronology;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с хронологией заказа
    /// </summary>
    public interface IOrderHronologyService
    {
        /// <summary>
        ///  Получает список хронлогий
        /// </summary>
        /// <returns>Список всех хронологий</returns>
        Task<List<OrderHronologyDto>> GetOrderHronologys();

        /// <summary>
        /// Получает хронологию по номеру заказа
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns>Модель хронологии заказа</returns>
        Task<List<OrderHronologyDto>> GetOrderHronologyById(Guid id);

        /// <summary>
        /// Добавляет хронологию
        /// </summary>
        /// <param name="model">Модель хронологии</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(OrderHronologyDto model);

        /// <summary>
        /// Удаляет хронологию
        /// </summary>
        /// <param name="id">id хронологии</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущую хронологию
        /// </summary>
        /// <param name="model">Модель хронологии</param>
        /// <returns>Обновленную модель</returns>
        Task<OrderHronologyDto> UpdateAsync(OrderHronologyDto model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Order;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с заказом
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        ///  Получает список всех заказов
        /// </summary>
        /// <returns>Список всех заказов</returns>
        Task<List<OrderDto>> GetOrders();

        /// <summary>
        /// Добавляет заказ
        /// </summary>
        /// <param name="model">Модель заказа</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(OrderDto model);

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущий заказ
        /// </summary>
        /// <param name="model">Модель заказа</param>
        /// <returns>Обновленную модель</returns>
        Task<OrderDto> UpdateAsync(OrderDto model);
    }
}

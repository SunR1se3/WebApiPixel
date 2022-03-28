using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Ware;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с товарами
    /// </summary>
    public interface IWareService
    {
        /// <summary>
        ///  Получает список всех товаров
        /// </summary>
        /// <returns>Список всех товаров</returns>
        Task<List<WareDto>> GetWares();

        /// <summary>
        /// Добавляет товар
        /// </summary>
        /// <param name="model">Модель товара</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(WareDto model);

        /// <summary>
        /// Удаляет товар
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущий товар
        /// </summary>
        /// <param name="model">Модель товара</param>
        /// <returns>Обновленную модель</returns>
        Task<WareDto> UpdateAsync(WareDto model);
    }
}

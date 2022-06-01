using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с предлагаемыми услугами на главной страницы
    /// </summary>
    public interface IOfferMainPageService
    {
        /// <summary>
        ///  Получает список всех услуг
        /// </summary>
        /// <returns>Список всех услуг</returns>
        Task<List<OfferMainPage>> GetOffers();

        /// <summary>
        /// Добавляет услугу
        /// </summary>
        /// <param name="model">Модель услуги</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(OfferMainPage model);

        /// <summary>
        /// Удаляет услугу
        /// </summary>
        /// <param name="id">id услуги</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущую услугу
        /// </summary>
        /// <param name="model">Модель услуги</param>
        /// <returns>Обновленную модель</returns>
        Task<OfferMainPage> UpdateAsync(OfferMainPage model);
    }
}

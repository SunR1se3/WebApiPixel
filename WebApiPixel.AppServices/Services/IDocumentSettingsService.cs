using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.DocumentSettings;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с параметрами тиражирования документов
    /// </summary>
    public interface IDocumentSettingsService
    {
        /// <summary>
        ///  Получает список всех параметров
        /// </summary>
        /// <returns>Список всех параметров</returns>
        Task<List<DocumentSettingsDto>> GetDocumentSettings();

        /// <summary>
        /// Получает параметр по id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Модель параметра</returns>
        Task<DocumentSettingsDto> GetDocumentSettingsById(Guid id);

        /// <summary>
        /// Добавляет параметр
        /// </summary>
        /// <param name="model">Модель параметра</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(DocumentSettingsDto model);

        /// <summary>
        /// Удаляет параметр
        /// </summary>
        /// <param name="id">id параметра</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущий параметр
        /// </summary>
        /// <param name="model">Модель параметра</param>
        /// <returns>Обновленную модель</returns>
        Task<DocumentSettingsDto> UpdateAsync(DocumentSettingsDto model);
    }
}

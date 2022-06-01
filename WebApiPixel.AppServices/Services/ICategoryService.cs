using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Category;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с категориями
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        ///  Получает список всех категорий
        /// </summary>
        /// <returns>Список всех категорий</returns>
        Task<List<CategoryDto>> GetCategories();

        /// <summary>
        /// Получает категорию по имени
        /// </summary>
        /// <param name="name">Имя категории</param>
        /// <returns>Модель категории</returns>
        Task<CategoryDto> GetCategoryByName(string name);

        /// <summary>
        /// Добавляет категорию
        /// </summary>
        /// <param name="model">Модель категории</param>
        /// <returns>Успех/неудача добавления</returns>
        Task AddAsync(CategoryDto model);

        /// <summary>
        /// Удаляет категорию
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns>Успех/неудачу удаления</returns>
        Task RemoveAsync(Guid id);

        /// <summary>
        /// Редактирует текущую категорию
        /// </summary>
        /// <param name="model">Модель категории</param>
        /// <returns>Обновленную модель</returns>
        Task<CategoryDto> UpdateAsync(CategoryDto model);
    }
}

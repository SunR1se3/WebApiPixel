using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;

namespace WebApiPixels.AppServices.Sevices
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
        List<Category> GetCategories();

        /// <summary>
        /// Добавляет категорию
        /// </summary>
        /// <param name="model">Модель категории</param>
        /// <returns>Успех/неудача добавления</returns>
        bool Add(Category model);

        /// <summary>
        /// Удаляет категорию
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns>Успех/неудачу удаления</returns>
        bool Remove(Guid id);

        /// <summary>
        /// Редактирует текущую категорию
        /// </summary>
        /// <param name="model">Модель категории</param>
        /// <returns>Обновленную модель</returns>
        Category Update(Category model);
    }
}

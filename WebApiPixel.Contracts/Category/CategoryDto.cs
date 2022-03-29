using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Ware;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.Contracts.Category
{
    /// <summary>
    /// Модель представления категории товаров
    /// </summary>
    public class CategoryDto : DtoBase
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Доступность категории для пользователя
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Коллекция товаров
        /// </summary>
        //public virtual List<WareDto> WaresDto { get; set; }
    }
}

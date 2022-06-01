using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.Contracts.DocumentSettings
{
    /// <summary>
    /// Модель представления параметров для тиражирования документов
    /// </summary>
    public class DocumentSettingsDto : DtoBase
    {
        /// <summary>
        /// Название параметра
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Id товара, к которому относится параметр
        /// </summary>
        public Guid WareId { get; set; }
    }
}

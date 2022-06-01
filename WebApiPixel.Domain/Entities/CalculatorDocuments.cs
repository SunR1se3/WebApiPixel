using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities.Base;

namespace WebApiPixel.Domain.Entities
{
    /// <summary>
    /// Калькулятор для тиражирования документов
    /// </summary>
    public class CalculatorDocuments
    {
        /// <summary>
        /// id размера бумаги
        /// </summary>
        public Guid IdSize { get; set; }

        /// <summary>
        /// id материала бумаги
        /// </summary>
        public Guid IdMaterial { get; set; }

        /// <summary>
        /// id плотности бумаги
        /// </summary>
        public Guid IdDensity { get; set; }

        /// <summary>
        /// id цвета бумаги
        /// </summary>
        public Guid IdColor { get; set; }

        /// <summary>
        /// Количество копий
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Дата выполнения
        /// </summary>
        public string Deadline { get; set; }

    }
}

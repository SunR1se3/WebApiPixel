using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.CalculatorDocuments;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.AppServices.Services
{
    /// <summary>
    /// Сервис для расчет стоимости товара "Тиражирование документов"
    /// </summary>
    public interface ICalculatorDocumentsService
    {
        /// <summary>
        /// Рассчитывает стоимость заказа с учетом выбранных параметров
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public float CalculatePriceDocument();


        /// <summary>
        /// Добавляет данные параметров
        /// </summary>
        /// <param name="model">Модель параметров</param>
        /// <returns>Успех/неудачу добавления</returns>
        public float GetPrice(CalculatorDocuments model);

    }
}

using Microsoft.AspNetCore.Mvc;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.CalculatorDocuments;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Калькулятор для тиражирования документов
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorDocumentsController : ControllerBase
    {
        private readonly ILogger<CalculatorDocumentsController> _logger;
        private readonly ICalculatorDocumentsService _calculatorDocumentsService;

        /// <summary>
        /// Конструктор. Внедрение зависимостей через конструктор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="calculatorDocumentsService">Сервис, обслуживающий контроллер</param>
        public CalculatorDocumentsController(ILogger<CalculatorDocumentsController> logger, ICalculatorDocumentsService calculatorDocumentsService)
        {
            _logger = logger;
            _calculatorDocumentsService = calculatorDocumentsService;
        }

        /// <summary>
        /// Добавить параметры для тиражирования документов
        /// </summary>
        /// <param name="model">модель параметров</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetPriceDocument([FromQuery] CalculatorDocuments model)
        {
            var result = _calculatorDocumentsService.GetPrice(model);
            return Ok(result);
        }
    }
}

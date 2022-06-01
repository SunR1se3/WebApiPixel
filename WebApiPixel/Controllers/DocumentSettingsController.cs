using Microsoft.AspNetCore.Mvc;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.DocumentSettings;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Параметры для тиражирования документов
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentSettingsController : ControllerBase
    {
        private readonly ILogger<DocumentSettingsController> _logger;
        private readonly IDocumentSettingsService _documentSettingsService;

        /// <summary>
        /// Конструктор. Введение зависимостей через конструктор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="documentSettingsService">Сервис, обслуживающий контроллер</param>
        public DocumentSettingsController(ILogger<DocumentSettingsController> logger, IDocumentSettingsService documentSettingsService)
        {
            _logger = logger;
            _documentSettingsService = documentSettingsService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех параметров</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _documentSettingsService.GetDocumentSettings();
            return Ok(result);
        }

        /// <summary>
        /// Получает параметр по id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Параметр</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _documentSettingsService.GetDocumentSettingsById(id);
            return Ok(result);
        }

        /// <summary>
        /// Добавить параметр
        /// </summary>
        /// <param name="model">Модель параметра</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] DocumentSettingsDto model)
        {
            await _documentSettingsService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель параметра</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] DocumentSettingsDto model)
        {
            var result = await _documentSettingsService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет параметр
        /// </summary>
        /// <param name="id">id параметра</param>
        /// <returns>Успех/недуачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _documentSettingsService.RemoveAsync(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApiPixel.Domain.Entities;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.Ware;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Товар
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WareController : ControllerBase
    {
        private readonly ILogger<WareController> _logger;
        private readonly IWareService _wareService;

        /// <summary>
        /// Конструктор. Внедрение зависимостей через конструктор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="wareService">Сервис, обслуживающий контроллер</param>
        public WareController(ILogger<WareController> logger, IWareService wareService)
        {
            _logger = logger;
            _wareService = wareService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех товаров</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _wareService.GetWares();
            return Ok(result);
        }

        /// <summary>
        /// Добавить товар
        /// </summary>
        /// <param name="model">Модель товара</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] WareDto model)
        {
            await _wareService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель товара</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] WareDto model)
        {
            var result = await _wareService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет товар
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>Успех/неудачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _wareService.RemoveAsync(id);
            return Ok();
        }
    }
}

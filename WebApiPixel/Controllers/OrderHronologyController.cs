using Microsoft.AspNetCore.Mvc;
using WebApiPixel.Domain.Entities;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.Employee;
using WebApiPixel.Contracts.OrderHronology;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Хронология заказа
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHronologyController : ControllerBase
    {
        private readonly ILogger<OrderHronologyController> _logger;
        private readonly IOrderHronologyService _orderHronologyService;

        public OrderHronologyController(ILogger<OrderHronologyController> logger, IOrderHronologyService orderHronologyService)
        {
            _logger = logger;
            _orderHronologyService = orderHronologyService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех хронлогий</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _orderHronologyService.GetOrderHronologys();
            return Ok(result);
        }

        /// <summary>
        /// Получает хронологию заказа по id заказа
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns>Модель хронлогии заказа</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _orderHronologyService.GetOrderHronologyById(id);
            return Ok(result);
        }

        /// <summary>
        /// Добавить хронлогию
        /// </summary>
        /// <param name="model">Модель хронологии</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] OrderHronologyDto model)
        {
            await _orderHronologyService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель хронологии</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] OrderHronologyDto model)
        {
            var result = await _orderHronologyService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет хронологию
        /// </summary>
        /// <param name="id">id хронологии</param>
        /// <returns>Успех/неудачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _orderHronologyService.RemoveAsync(id);
            return Ok();
        }
    }
}

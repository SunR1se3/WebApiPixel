using Microsoft.AspNetCore.Mvc;
using WebApiPixel.Domain.Entities;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.Order;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Заказ
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех заказов</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        /// <summary>
        /// Получить заказ по id
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns>Модель заказа</returns>
        [HttpGet("/order/{id}")]
        public async Task<IActionResult> GetByIdOrder([FromRoute] Guid id)
        {
            var result = await _orderService.GetOrderById(id);
            return Ok(result);
        }

        /// <summary>
        /// Получить последний элемент
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, [FromQuery] string email)
        {
            var result = await _orderService.GetLastOrder();
            if (email != "null") _orderService.SendEmailAsync(id, email);
            return Ok(result);
        }

        /// <summary>
        /// Добавить заказ
        /// </summary>
        /// <param name="model">Модель заказа</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] OrderDto model)
        {
            //await _orderService.SaveFile(formFile);
            await _orderService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель заказа</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] OrderDto model)
        {
            var result = await _orderService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns>Успех/неудачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _orderService.RemoveAsync(id);
            return Ok();
        }
    }
}

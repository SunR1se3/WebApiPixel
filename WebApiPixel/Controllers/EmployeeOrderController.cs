using Microsoft.AspNetCore.Mvc;
using WebApiPixel.Domain.Entities;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.Employee;
using WebApiPixel.Contracts.EmployeeOrderDto;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// СотрудникЗаказ
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeOrderController : ControllerBase
    {
        private readonly ILogger<EmployeeOrderController> _logger;
        private readonly IEmployeeOrderService _employeeOrderService;

        public EmployeeOrderController(ILogger<EmployeeOrderController> logger, IEmployeeOrderService employeeOrderService)
        {
            _logger = logger;
            _employeeOrderService = employeeOrderService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех записей</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeOrderService.GetEmployeeOrders();
            return Ok(result);
        }

        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="model">Модель СотрудникЗаказ</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] EmployeeOrderDto model)
        {
            await _employeeOrderService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель СотрудникЗаказ</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] EmployeeOrderDto model)
        {
            var result = await _employeeOrderService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns>Успех/неудачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _employeeOrderService.RemoveAsync(id);
            return Ok();
        }
    }
}

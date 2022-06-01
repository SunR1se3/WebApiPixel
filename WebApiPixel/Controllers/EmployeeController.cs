using Microsoft.AspNetCore.Mvc;
using WebApiPixel.Domain.Entities;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.Employee;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех сотрудников</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeService.GetEmployees();
            return Ok(result);
        }

        /// <summary>
        /// Вход сотрудника
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        [HttpGet("{login}/{password}")]
        public async Task<IActionResult> LoginEmploeey([FromRoute] string login, [FromRoute] string password)
        {
            var result = await _employeeService.Login(login, password);
            return Ok(result);
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="model">Модель сотрудника</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] EmployeeDto model)
        {
            await _employeeService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель сотрудника</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] EmployeeDto model)
        {
            var result = await _employeeService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет сотрудника
        /// </summary>
        /// <param name="id">id сотрудника</param>
        /// <returns>Успех/неудачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _employeeService.RemoveAsync(id);
            return Ok();
        }
    }
}

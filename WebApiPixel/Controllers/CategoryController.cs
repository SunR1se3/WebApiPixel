using Microsoft.AspNetCore.Mvc;
using WebApiPixel.Domain.Entities;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Contracts.Category;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Категория
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Конструктор. Введение зависимостей через конструктор
        /// </summary>
        /// <param name="logger">Логирование</param>
        /// <param name="categoryService">Сервис, обслуживающий контроллер</param>
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех категорий</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetCategories();
            return Ok(result);
        }
        /// <summary>
        /// Получить категорию по имени
        /// </summary>
        /// <param name="name">Имя категории</param>
        /// <returns>Модель категории</returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var result = await _categoryService.GetCategoryByName(name);
            return Ok(result);
        }

        /// <summary>
        /// Добавить категорию
        /// </summary>
        /// <param name="model">Модель категории</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] CategoryDto model)
        {
            await _categoryService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель категороии</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] CategoryDto model)
        {
            var result = await _categoryService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет категорию
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns>Успех/недуачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _categoryService.RemoveAsync(id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApiPixel.Domain.Entities;
using WebApiPixel.AppServices.Services;

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
            return Ok(_categoryService.GetCategories());
        }

        /// <summary>
        /// Добавить категорию
        /// </summary>
        /// <param name="model">Модель категории</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] Category model)
        {
            var result = _categoryService.Add(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель категороии</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Category model)
        {
            var result = _categoryService.Update(model);
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
            var result = _categoryService.Remove(id);
            return Ok(result.ToString());
        }
    }
}

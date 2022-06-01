using Microsoft.AspNetCore.Mvc;
using WebApiPixel.AppServices.Services;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Главная страница: список услуг
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OfferMainPageController : ControllerBase
    {
        private readonly ILogger<OfferMainPageController> _logger;
        private readonly IOfferMainPageService _offerMainPageService;

        public OfferMainPageController(ILogger<OfferMainPageController> logger, IOfferMainPageService offerMainPageService)
        {
            _logger = logger;
            _offerMainPageService = offerMainPageService;
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <returns>Список всех услуг</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _offerMainPageService.GetOffers();
            return Ok(result);
        }

        /// <summary>
        /// Добавить услугу
        /// </summary>
        /// <param name="model">Модель услуги</param>
        /// <returns>Успех/неудачу добавления</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] OfferMainPage model)
        {
            await _offerMainPageService.AddAsync(model);
            return Created(String.Empty, null);
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="model">Модель услуги</param>
        /// <returns>Успех/неудачу редактирования</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] OfferMainPage model)
        {
            var result = await _offerMainPageService.UpdateAsync(model);
            return Ok(result.ToString());
        }

        /// <summary>
        /// Удаляет услугу
        /// </summary>
        /// <param name="id">id услуги</param>
        /// <returns>Успех/неудачу удаления</returns>
        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            await _offerMainPageService.RemoveAsync(id);
            return Ok();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using WebApiPixel.AppServices.Services;

namespace WebApiPixel.Controllers
{
    /// <summary>
    /// Работа с файлами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm]IFormFile data)
        {
            var result = _fileService.Upload(data);
            return Ok(result);
        }
    }
}

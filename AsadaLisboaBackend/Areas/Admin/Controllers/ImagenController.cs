using Microsoft.AspNetCore.Mvc;
using AsadaLisboaBackend.Models.DTOs.Image;
using AsadaLisboaBackend.Utils.OptionsPattern;
using AsadaLisboaBackend.ServiceContracts.Image;

namespace AsadaLisboaBackend.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class ImagenController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;

        public ImagenController(IImageService imageService, IWebHostEnvironment env)
        {
            _imageService = imageService;
            _env = env;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateImage([FromForm] ImageRequestDTO imageRequestDTO)
        {
            var options = new FileStorageOptions
            {
                BasePath = Path.Combine(_env.WebRootPath, "uploads"),
                BaseUrl = "/uploads"
            };

            var result = await _imageService.CreateImage(imageRequestDTO, options);
            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditImage([FromForm] ImageUpdateRequestDTO ImageUpdateRequestDTO)
        {
            var options = new FileStorageOptions
            {
                BasePath = Path.Combine(_env.WebRootPath, "uploads"),
                BaseUrl = "/uploads"
            };

            try
            {
                var result = await _imageService.UpdateImage(ImageUpdateRequestDTO, options);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            try
            {
                var result = await _imageService.DeleteImage(id);
                return Ok(new { success = result, message = "Imagen eliminada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}

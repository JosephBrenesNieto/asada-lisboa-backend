using Microsoft.AspNetCore.Mvc;
using AsadaLisboaBackend.Models.DTOs.Image;
using AsadaLisboaBackend.ServiceContracts.Image;

namespace AsadaLisboaBackend.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class ImagenController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagenController(IImageService imageService)
        {

            _imageService = imageService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateImage([FromForm] ImageRequestDTO imageRequestDTO)
        {
            var result = await _imageService.CreateImage(imageRequestDTO);
            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditImage([FromForm] ImageUpdateRequestDTO ImageUpdateRequestDTO)
        {
            try
            {
                var result = await _imageService.UpdateImage(ImageUpdateRequestDTO);
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

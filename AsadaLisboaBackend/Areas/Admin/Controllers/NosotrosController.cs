using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.AboutUs;
using AsadaLisboaBackend.ServiceContracts.AboutUsSections;

namespace AsadaLisboaBackend.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [ApiVersion("1.0")]
    [Route("api/[area]/[controller]")]
    public class NosotrosController : ControllerBase
    {
        private readonly IAboutUsSectionsAdderService _aboutUsSectionsAdderService;
        private readonly IAboutUsSectionsGetterService _aboutUsSectionsGetterService;
        private readonly IAboutUsSectionsDeleterService _aboutUsSectionsDeleterService;
        private readonly IAboutUsSectionsUpdaterService _aboutUsSectionsUpdaterService;

        public NosotrosController(IAboutUsSectionsAdderService aboutUsSectionsAdderService, IAboutUsSectionsGetterService aboutUsSectionsGetterService, IAboutUsSectionsDeleterService aboutUsSectionsDeleterService, IAboutUsSectionsUpdaterService aboutUsSectionsUpdaterService)
        {
            _aboutUsSectionsAdderService = aboutUsSectionsAdderService;
            _aboutUsSectionsGetterService = aboutUsSectionsGetterService;
            _aboutUsSectionsDeleterService = aboutUsSectionsDeleterService;
            _aboutUsSectionsUpdaterService = aboutUsSectionsUpdaterService;
        }

        [HttpGet("")]
        public async Task<ActionResult<PageResponseDTO<AboutUsResponseDTO>>> GetAboutUsSections([FromQuery] SearchSortRequestDTO searchSortRequestDTO)
        {
            return Ok(await _aboutUsSectionsGetterService.GetAboutUsSections(searchSortRequestDTO));
        }

        [HttpPost("")]
        public async Task<ActionResult<AboutUsResponseDTO>> CreateAboutUsSection([FromForm] AboutUsRequestDTO aboutUsSectionRequestDTO)
        {
            return Created("~/api/admin/nosotros", await _aboutUsSectionsAdderService.CreateAboutUsSection(aboutUsSectionRequestDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AboutUsResponseDTO>> UpdateAboutUsSection([FromRoute] Guid id, [FromForm] AboutUsRequestDTO aboutUsSectionRequestDTO)
        {
            return Ok(await _aboutUsSectionsUpdaterService.UpdateAboutUsSection(id, aboutUsSectionRequestDTO));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AboutUsResponseDTO>> DeleteAboutUsSection([FromRoute] Guid id)
        {
            await _aboutUsSectionsDeleterService.DeleteAboutUsSection(id);
            return NoContent();
        }
    }
}

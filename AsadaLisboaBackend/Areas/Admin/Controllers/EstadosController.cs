using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using AsadaLisboaBackend.Models.DTOs.Status;
using AsadaLisboaBackend.ServiceContracts.Statuses;

namespace AsadaLisboaBackend.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [ApiVersion("1.0")]
    [Route("api/[area]/[controller]")]
    public class EstadosController : ControllerBase
    {
        private readonly IStatusesGetterService _statusesGetterService;

        public EstadosController(IStatusesGetterService statusesGetterService)
        {
            _statusesGetterService = statusesGetterService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<StatusResponseDTO>>> GetStatuses()
        {
            return Ok(await _statusesGetterService.GetStatuses());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsadaLisboaBackend.ServiceContracts.Document;
using AsadaLisboaBackend.Models.DTOs.Document;
using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Utils.OptionsPattern;


namespace AsadaLisboaBackend.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class DocumentoController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IDocumentService _documentService;
        private readonly IDocumentGetterService _documentGetterService;

        public DocumentoController(IWebHostEnvironment env, IDocumentService documentService, IDocumentGetterService documentGetterService)
        {
            _env = env;
            _documentService = documentService;
            _documentGetterService = documentGetterService;
        }

        [HttpGet("")]
        public async Task<ActionResult<PageResponseDTO<DocumentResponseDTO>>> GetDocument([FromQuery] SearchSortRequestDTO searchSortRequestDTO)
        {
            return Ok(await _documentGetterService.GetDocument(searchSortRequestDTO));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PageResponseDTO<DocumentResponseDTO>>> GetDocument([FromRoute] Guid id)
        {
            return Ok(await _documentGetterService.GetDocument(id));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateDocument([FromForm] DocumentRequestDTO documentRequestDTO)
        {
            var options = new FileStorageOptions
            {
                BasePath = Path.Combine(_env.WebRootPath, "uploads"),
                BaseUrl = "/uploads"
            };

            var result = await _documentService.CreateDocument(documentRequestDTO, options);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditDocument([FromRoute] Guid id, [FromForm] DocumentUpdateRequestDTO documentUpdateRequestDTO)
        {
            var options = new FileStorageOptions
            {
                BasePath = Path.Combine(_env.WebRootPath, "uploads"),
                BaseUrl = "/uploads"
            };

            var result = await _documentService.UpdateDocument(id, DocumentUpdateRequestDTO, options);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            await _documentService.DeleteDocument(id);
            return NoContent();
        }

    }
}

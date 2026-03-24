using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.Models.DTOs.Document;
using AsadaLisboaBackend.Models.DTOs.Image;
using AsadaLisboaBackend.ServiceContracts.Document;


namespace AsadaLisboaBackend.Services.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DocumentService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<DocumentResponseDTO> CreateDocument(DocumentRequestDTO documentRequestDTO)
        {
             // Guardar archivo físico
           
            var fileName = $"{Guid.NewGuid()}_{documentRequestDTO.File.FileName}";
            var filePath = Path.Combine(AppContext.BaseDirectory, "uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {

                await documentRequestDTO.File.CopyToAsync(stream);
            }



            var newDocument = new Models.Document()
            {
                Id = Guid.NewGuid(),
                Title = documentRequestDTO.Title,
                Description = documentRequestDTO.Description,
                Slug = documentRequestDTO.Title.ToLower().Replace(" ", "-"),
                PublicationDate = DateTime.UtcNow,
                FileSize = documentRequestDTO.File.Length,
                StatusId = documentRequestDTO.StatusId,
                DocumentTypeId = documentRequestDTO.DocumentTypeId,
                Categories = _applicationDbContext.Categories
                .Where(c => documentRequestDTO.CategoryIds.Contains(c.Id))
                .ToList()
            };

            _applicationDbContext.Documents.Add(newDocument);
            await _applicationDbContext.SaveChangesAsync();

            return new  DocumentResponseDTO{

                Id = newDocument.Id,
                Slug = newDocument.Slug,
                Title = newDocument.Title,
                Description = newDocument.Description,
                PublicationDate = newDocument.PublicationDate,
                FileSize = newDocument.FileSize,
                StatusName = newDocument.Status?.Name ?? string.Empty,
                Categories = newDocument.Categories.Select(c => c.Name).ToList()
            };
        }
    }
}

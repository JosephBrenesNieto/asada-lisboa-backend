using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.RepositoryContracts.Documents;

namespace AsadaLisboaBackend.Repositories.Documents
{
    public class DocumentsUpdaterRepository : IDocumentsUpdaterRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentsUpdaterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Document> UpdateDocument(Models.Document document)
        {
            _context.Attach(document);

            _context.Entry(document).Property(n => n.Title).IsModified = true;
            _context.Entry(document).Property(n => n.Description).IsModified = true;
            _context.Entry(document).Property(n => n.Slug).IsModified = true;
            _context.Entry(document).Property(n => n.StatusId).IsModified = true;
            _context.Entry(document).Property(n => n.FileSize).IsModified = true;
            _context.Entry(document).Property(n => n.DocumentTypeId).IsModified = true;
            _context.Entry(document).Property(n => n.Categories).IsModified = true;

            var affectedRows = await _context.SaveChangesAsync();

            if (affectedRows < 1)
                throw new UpdateObjectException("Error al modificar el documento");

            return new Models.Document()
            {
                Id = document.Id,
                Url = document.Url,
                Slug = document.Slug,
                Title = document.Title,
                Status = document.Status,
                FileSize = document.FileSize,
                StatusId = document.StatusId,
                FileName = document.FileName,
                FilePath = document.FilePath,
                Categories = document.Categories,
                Description = document.Description,
                DocumentTypeId = document.DocumentTypeId,
                PublicationDate = document.PublicationDate,
            };
        }
    }
}

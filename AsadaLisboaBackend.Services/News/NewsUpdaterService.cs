using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DTOs.New;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.ServiceContracts.News;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.ServiceContracts.Editor;
using AsadaLisboaBackend.RepositoryContracts.News;
using AsadaLisboaBackend.ServiceContracts.FileSystem;

namespace AsadaLisboaBackend.Services.News
{
    public class NewsUpdaterService : INewsUpdaterService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileSystemManager _fileSystem;
        private readonly IEditorUpdaterService _editorUpdaterService;
        private readonly INewsGetterRepository _newsGetterRepository;
        private readonly IEditorDeleterService _editorDeleterService;
        private readonly INewsUpdaterRepository _newsUpdaterRepository;

        public NewsUpdaterService(INewsUpdaterRepository newsUpdaterRepository, INewsGetterRepository newsGetterRepository, IEditorUpdaterService editorUpdaterService, IEditorDeleterService editorDeleterService, ApplicationDbContext context, IFileSystemManager fileSystem)
        {
            _context = context;
            _fileSystem = fileSystem;
            _editorDeleterService = editorDeleterService;
            _editorUpdaterService = editorUpdaterService;
            _newsGetterRepository = newsGetterRepository;
            _newsUpdaterRepository = newsUpdaterRepository;
        }

        public async Task<NewResponseDTO> UpdateNew(Guid id, NewRequestDTO newRequestDTO)
        {
            var existingNew = await _newsGetterRepository.GetNew(id);

            var imageUrl = existingNew.ImageUrl;
            var fileName = existingNew.FileName;
            var filePath = existingNew.FilePath;

            if (newRequestDTO.File is not null)
            {
                var newImageUrl = await _fileSystem.SaveAsync(newRequestDTO.File, "news");

                if (!string.IsNullOrEmpty(existingNew.FileName))
                    await _fileSystem.DeleteAsync(existingNew.FileName, "news");

                imageUrl = newImageUrl;
                fileName = Path.GetFileName(imageUrl);
                filePath = $"news/{fileName}";
            }

            var content = await _editorUpdaterService.ChangeHtmlImagesFolder(newRequestDTO.Description);
            await _editorDeleterService.DeleteUnusedImages(existingNew.Description, newRequestDTO.Description);

            var categories = await _context.Categories
                .Where(c => newRequestDTO.CategoryIds.Contains(c.Id))
                .ToListAsync();

            var newModel = new New()
            {
                Id = id,
                ImageUrl = imageUrl,
                FileName = fileName,
                FilePath = filePath,
                Description = content,
                Categories = categories,
                Slug = existingNew.Slug,
                Title = newRequestDTO.Title,
                StatusId = newRequestDTO.StatusId,
                LastEditionDate = DateTime.UtcNow,
                PublicationDate = existingNew.PublicationDate,
            };

            var created = await _newsUpdaterRepository.UpdateNew(id, newModel);

            if (created is null)
                throw new CreateObjectException("Error al crear la noticia.");

            return created.ToNewResponseDTO();
        }
    }
}

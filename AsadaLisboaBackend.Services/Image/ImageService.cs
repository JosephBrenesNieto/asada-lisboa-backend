using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Models.DTOs.Image;
using AsadaLisboaBackend.Utils.OptionsPattern;
using AsadaLisboaBackend.Utils.SlugGeneration;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.ServiceContracts.Image;

namespace AsadaLisboaBackend.Services.Image
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ImageService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ImageResponseDTO> CreateImage(ImageRequestDTO imageRequestDTO, FileStorageOptions fileStorageOptions)
        {
            if (imageRequestDTO.File == null || imageRequestDTO.File.Length == 0)
                throw new ArgumentException("Archivo inválido");

            var imageId = Guid.NewGuid();
            var extension = Path.GetExtension(imageRequestDTO.File.FileName).ToLowerInvariant();

            // Guardar archivo físico
            var fileName = $"{imageId}{extension}";
            var filePath = Path.Combine(fileStorageOptions.BasePath, fileName);

            if (!Directory.Exists(fileStorageOptions.BasePath))
                Directory.CreateDirectory(fileStorageOptions.BasePath);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageRequestDTO.File.CopyToAsync(stream);
                }

                var fileUrl = $"{fileStorageOptions.BaseUrl}{fileName}";
                var slug = GenerateSlug.New(imageRequestDTO.Title, imageId);
                var categories = await _applicationDbContext.Categories
                    .Where(c => imageRequestDTO.CategoryIds.Contains(c.Id))
                    .ToListAsync();

                var image = new Models.Image()
                { 
                    Id = imageId,
                    Slug = slug,          
                    Url = fileUrl,
                    FilePath = filePath,
                    FileName = fileName,
                    Categories = categories,
                    Title = imageRequestDTO.Title,
                    PublicationDate = DateTime.UtcNow,
                    StatusId = imageRequestDTO.StatusId,
                    FileSize = imageRequestDTO.File.Length,
                    Description = imageRequestDTO.Description,
                };

                _applicationDbContext.Images.Add(image);
                await _applicationDbContext.SaveChangesAsync();

                return new ImageResponseDTO
                {
                    Id = image.Id,
                    Slug = image.Slug,
                    Title = image.Title,
                    FileSize = image.FileSize,
                    Description = image.Description,
                    PublicationDate = image.PublicationDate,
                    StatusName = image.Status?.Name ?? string.Empty,
                    Categories = image.Categories.Select(c => c.Name).ToList()
                };
            }
            catch
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                throw new Exception("");
            }
        }

        public async Task<ImageResponseDTO> UpdateImage(ImageUpdateRequestDTO imageUpdateRequestDTO, FileStorageOptions fileStorageOptions)
        {
            var image = await _applicationDbContext.Images
                .Include(i => i.Categories)
                .FirstOrDefaultAsync(i => i.Id == imageUpdateRequestDTO.Id);

            if (image == null)
                throw new Exception("Imagen no encontrada");

             //Actualizar datos y generar nuevo Slug
            image.Title = imageUpdateRequestDTO.Title;
            image.StatusId = imageUpdateRequestDTO.StatusId;
            image.Description = imageUpdateRequestDTO.Description;

            image.Slug = GenerateSlug.New(imageUpdateRequestDTO.Title, image.Id);

            var categories = await _applicationDbContext.Categories
                .Where(c => imageUpdateRequestDTO.CategoryIds.Contains(c.Id))
                .ToListAsync();

            image.Categories.Clear();
            image.Categories = categories;

            // Si hay nueva imagen, reemplazar archivo
            if (imageUpdateRequestDTO.File != null && imageUpdateRequestDTO.File.Length > 0)
            {
                var extension = Path.GetExtension(imageUpdateRequestDTO.File.FileName).ToLowerInvariant();
                var newFileName = $"{image.Id}{extension}";
                var newFilePath = Path.Combine(fileStorageOptions.BasePath, newFileName);

                try
                {
                    // Guardar nueva imagen
                    using (var stream = new FileStream(newFilePath, FileMode.Create))
                    {
                        await imageUpdateRequestDTO.File.CopyToAsync(stream);
                    }

                    // Eliminar anterior (si existe y es distinto)
                    if (!string.IsNullOrEmpty(image.FilePath) &&
                        File.Exists(image.FilePath) &&
                        image.FilePath != newFilePath)
                    {
                        File.Delete(image.FilePath);
                    }

                    // Actualizar metadata
                    image.FileName = newFileName;
                    image.FilePath = newFilePath;
                    image.Url = $"{fileStorageOptions.BaseUrl}{newFileName}";
                    image.FileSize = imageUpdateRequestDTO.File.Length;
                }
                catch
                {
                    // rollback si falla
                    if (File.Exists(newFilePath))
                        File.Delete(newFilePath);

                    throw new Exception("");
                }
            }

            await _applicationDbContext.SaveChangesAsync();

            return new ImageResponseDTO
            {
                Id = image.Id,
                Slug = image.Slug,
                Title = image.Title,
                FileSize = image.FileSize,
                Description = image.Description,
                StatusName = image.Status?.Name ?? "",
                PublicationDate = image.PublicationDate,
                Categories = image.Categories.Select(c => c.Name).ToList()
            };
        }

        public async Task<bool> DeleteImage(Guid id)
        {
            var image = await _applicationDbContext.Images
                .FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
                throw new Exception("Imagen no encontrada");

            try
            {
                // Eliminar archivo físico directamente
                if (!string.IsNullOrEmpty(image.FilePath) && File.Exists(image.FilePath))
                    File.Delete(image.FilePath);

                // Eliminar BD
                _applicationDbContext.Images.Remove(image);
                await _applicationDbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

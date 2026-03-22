using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Models.DTOs.Image;
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

        public async Task<ImageResponseDTO> CreateImage(ImageRequestDTO imageRequestDTO)
        {
            // Guardar archivo físico
            var fileName = $"{Guid.NewGuid()}_{imageRequestDTO.File.FileName}";
            var filePath = Path.Combine(AppContext.BaseDirectory, "uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageRequestDTO.File.CopyToAsync(stream);
            }


            var newImage = new Models.Image()
            { 
                Id = Guid.NewGuid(),
                Title = imageRequestDTO.Title,
                Description = imageRequestDTO.Description,
                Slug = imageRequestDTO.Title.ToLower().Replace(" ", "-"),                
                PublicationDate = DateTime.UtcNow,
                StatusId = imageRequestDTO.StatusId,
                Categories = _applicationDbContext.Categories
                .Where(c => imageRequestDTO.CategoryIds.Contains(c.Id))
                .ToList()
            };

            _applicationDbContext.Images.Add(newImage);
            await _applicationDbContext.SaveChangesAsync();

            return new ImageResponseDTO
            {
                Id = newImage.Id,
                Slug = newImage.Slug,
                Title = newImage.Title,
                Description = newImage.Description,
                PublicationDate = newImage.PublicationDate,
                FileSize = newImage.FileSize,
                StatusName = newImage.Status?.Name ?? string.Empty,
                Categories = newImage.Categories.Select(c => c.Name).ToList()
            };


        }

        public async Task<ImageResponseDTO> UpdateImage( ImageUpdateRequestDTO imageUpdateRequestDTO)
        {
            var image = await _applicationDbContext.Images.Include(i => i.Categories).FirstOrDefaultAsync(i => i.Id == imageUpdateRequestDTO.Id); ;

            if (image == null)
                throw new Exception("Imagen no encontrada");


             //Actualizar datos y generar nuevo Slug
            image.Title = imageUpdateRequestDTO.Title;
            image.Description = imageUpdateRequestDTO.Description;
            image.Slug = imageUpdateRequestDTO.Title.ToLower().Replace(" ", "-");
            image.StatusId = imageUpdateRequestDTO.StatusId;
            image.Categories.Clear();
            var categories = _applicationDbContext.Categories
                .Where(c => imageUpdateRequestDTO.CategoryIds.Contains(c.Id))
                .ToList();
            foreach (var cat in categories)
                image.Categories.Add(cat);


            // Si hay nueva imagen, reemplazar archivo
            if (imageUpdateRequestDTO.File != null)
            {
                var fileName = $"{Guid.NewGuid()}_{imageUpdateRequestDTO.File.FileName}";
                var filePath = Path.Combine(AppContext.BaseDirectory, "uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageUpdateRequestDTO.File.CopyToAsync(stream);
                }

                image.FileSize = imageUpdateRequestDTO.File.Length;
            
            }

            await _applicationDbContext.SaveChangesAsync();


            return new ImageResponseDTO {

                Id = image.Id,
                Slug = image.Slug,
                Title = image.Title,
                Description = image.Description,
                PublicationDate = image.PublicationDate,            
                StatusName = image.Status?.Name ?? "",
                Categories = image.Categories.Select(c => c.Name).ToList()


            };
        }

        public async Task<bool> DeleteImage(Guid id)
        {
            var image = await _applicationDbContext.Images
                .Include(i => i.Categories)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
                throw new Exception("Imagen no encontrada");


            // Eliminar archivo físico 
            var uploadsPath = Path.Combine(AppContext.BaseDirectory, "uploads");
            var filePattern = $"{image.Id}_*"; 
            var file = Directory.GetFiles(uploadsPath, filePattern).FirstOrDefault();

            if (file != null && File.Exists(file))
            {
                File.Delete(file);
            }

            // Eliminar de la base de datos
            _applicationDbContext.Images.Remove(image);
            await _applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.ServiceContracts.Image;
using AsadaLisboaBackend.ServiceContracts.FileSystem;

namespace AsadaLisboaBackend.Services.Image
{
    public class ImagesDeleterService : IImagesDeleterService
    {
        private readonly IFileSystemManager _fileSystem;
        private readonly ApplicationDbContext _applicationDbContext;

        public ImagesDeleterService(ApplicationDbContext applicationDbContext, IFileSystemManager fileSystem)
        {
            _fileSystem = fileSystem;
            _applicationDbContext = applicationDbContext;
        }

        public async Task DeleteImage(Guid id)
        {
            var image = await _applicationDbContext.Images
                .FirstOrDefaultAsync(i => i.Id == id);

            if (image is null)
                throw new NotFoundException("Imagen no encontrada.");

            if (!string.IsNullOrEmpty(image.FileName))
                await _fileSystem.DeleteAsync(image.FileName, "images");

            _applicationDbContext.Images.Remove(image);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}

using AsadaLisboaBackend.Models.DTOs.Image;
using AsadaLisboaBackend.Utils.OptionsPattern;

namespace AsadaLisboaBackend.ServiceContracts.Image
{
    public interface IImageService
    {
        public Task<ImageResponseDTO> CreateImage(ImageRequestDTO imageRequestDTO, FileStorageOptions fileStorageOptions);

        public Task<ImageResponseDTO> UpdateImage(ImageUpdateRequestDTO imageUpdateRequestDTO, FileStorageOptions fileStorageOptions);

        public Task<bool> DeleteImage(Guid id);

    }
}

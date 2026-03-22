using AsadaLisboaBackend.Models.DTOs.Image;

namespace AsadaLisboaBackend.ServiceContracts.Image
{
    public interface IImageService
    {
        public Task<ImageResponseDTO> CreateImage(ImageRequestDTO imageRequestDTO);

        public Task<ImageResponseDTO> UpdateImage(ImageUpdateRequestDTO imageUpdateRequestDTO);

        public Task<bool> DeleteImage(Guid id);

    }
}

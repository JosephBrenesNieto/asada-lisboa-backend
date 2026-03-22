using AsadaLisboaBackend.Models.DTOs.AboutUs;

namespace AsadaLisboaBackend.ServiceContracts.AboutUsSections
{
    public interface IAboutUsSectionsAdderService
    {
        public Task<AboutUsResponseDTO> CreateAboutUsSection(AboutUsRequestDTO aboutUsRequestDTO);
    }
}

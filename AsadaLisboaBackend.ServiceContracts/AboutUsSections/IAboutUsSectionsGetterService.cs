using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.AboutUs;

namespace AsadaLisboaBackend.ServiceContracts.AboutUsSections
{
    public interface IAboutUsSectionsGetterService
    {
        public Task<PageResponseDTO<AboutUsResponseDTO>> GetAboutUsSections(SearchSortRequestDTO searchSortRequestDTO);
    }
}

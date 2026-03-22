using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.AboutUs;

namespace AsadaLisboaBackend.RepositoryContracts.AboutUsSections
{
    public interface IAboutUsSectionsGetterRepository
    {
        public Task<PageResponseDTO<AboutUsResponseDTO>> GetAboutUsSections(SearchSortRequestDTO searchSortRequestDTO);
    }
}

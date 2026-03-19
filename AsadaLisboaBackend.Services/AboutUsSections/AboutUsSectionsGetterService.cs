using AsadaLisboaBackend.Models.DTOs.AboutUs;
using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.RepositoryContracts.AboutUsSections;
using AsadaLisboaBackend.RepositoryContracts.Contacts;
using AsadaLisboaBackend.ServiceContracts.AboutUsSections;

namespace AsadaLisboaBackend.Services.AboutUsSections
{
    public class AboutUsSectionsGetterService : IAboutUsSectionsGetterService
    {
        private readonly IAboutUsSectionsGetterRepository _aboutUsSectionsGetterRepository;

        public AboutUsSectionsGetterService(IAboutUsSectionsGetterRepository aboutUsSectionsGetterRepository)
        {
            _aboutUsSectionsGetterRepository = aboutUsSectionsGetterRepository;
        }

        public async Task<PageResponseDTO<AboutUsResponseDTO>> GetAboutUsSections(SearchSortRequestDTO searchSortRequestDTO)
        {
            searchSortRequestDTO.Offset = (Math.Max(searchSortRequestDTO.Page, 1) - 1) * searchSortRequestDTO.Take;

            return await _aboutUsSectionsGetterRepository.GetAboutUsSections(searchSortRequestDTO);
        }
    }
}

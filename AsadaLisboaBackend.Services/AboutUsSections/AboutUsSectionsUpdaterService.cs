using AsadaLisboaBackend.Models.DTOs.AboutUs;
using AsadaLisboaBackend.ServiceContracts.AboutUsSections;
using AsadaLisboaBackend.RepositoryContracts.AboutUsSections;

namespace AsadaLisboaBackend.Services.AboutUsSections
{
    public class AboutUsSectionsUpdaterService : IAboutUsSectionsUpdaterService
    {
        private readonly IAboutUsSectionsUpdaterRepository _aboutUsSectionsUpdaterRepository;

        public AboutUsSectionsUpdaterService(IAboutUsSectionsUpdaterRepository aboutUsSectionsUpdaterRepository)
        {
            _aboutUsSectionsUpdaterRepository = aboutUsSectionsUpdaterRepository;
        }

        public async Task<AboutUsResponseDTO> UpdateAboutUsSection(Guid id, AboutUsRequestDTO aboutUsRequestDTO)
        {
            return (await _aboutUsSectionsUpdaterRepository.UpdateAboutUsSection(id, aboutUsRequestDTO))
                .ToAboutUsResponseDTO();
        }
    }
}

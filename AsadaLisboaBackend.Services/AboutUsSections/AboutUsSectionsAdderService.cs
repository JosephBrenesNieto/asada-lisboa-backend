using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DTOs.AboutUs;
using AsadaLisboaBackend.ServiceContracts.AboutUsSections;
using AsadaLisboaBackend.RepositoryContracts.AboutUsSections;

namespace AsadaLisboaBackend.Services.AboutUsSections
{
    public class AboutUsSectionsAdderService : IAboutUsSectionsAdderService
    {
        private readonly IAboutUsSectionsAdderRepository _aboutUsSectionsAdderRepository;

        public AboutUsSectionsAdderService(IAboutUsSectionsAdderRepository aboutUsSectionsAdderRepository)
        {
            _aboutUsSectionsAdderRepository = aboutUsSectionsAdderRepository;
        }

        public async Task<AboutUsResponseDTO> CreateAboutUsSection(AboutUsRequestDTO aboutUsRequestDTO)
        {

            var aboutUsSection = new AboutUsSection()
            {
                Order = aboutUsRequestDTO.Order,
                Content = aboutUsRequestDTO.Content,
                SectionType = aboutUsRequestDTO.SectionType,
            };

            return (await _aboutUsSectionsAdderRepository.CreateAboutUsSection(aboutUsSection))
                .ToAboutUsResponseDTO();
        }
    }
}

using AsadaLisboaBackend.ServiceContracts.AboutUsSections;
using AsadaLisboaBackend.RepositoryContracts.AboutUsSections;

namespace AsadaLisboaBackend.Services.AboutUsSections
{
    public class AboutUsSectionsDeleterService : IAboutUsSectionsDeleterService
    {
        private readonly IAboutUsSectionsDeleterRepository _aboutUsSectionsDeleterRepository;

        public AboutUsSectionsDeleterService(IAboutUsSectionsDeleterRepository aboutUsSectionsDeleterRepository)
        {
            _aboutUsSectionsDeleterRepository = aboutUsSectionsDeleterRepository;
        }

        public async Task DeleteAboutUsSection(Guid id)
        {
            await _aboutUsSectionsDeleterRepository.DeleteAboutUsSection(id);
        }
    }
}

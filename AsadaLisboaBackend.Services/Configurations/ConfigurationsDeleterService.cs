using AsadaLisboaBackend.ServiceContracts.Configurations;
using AsadaLisboaBackend.RepositoryContracts.Configurations;

namespace AsadaLisboaBackend.Services.Configurations
{
    public class ConfigurationsDeleterService : IConfigurationsDeleterService
    {
        private readonly IConfigurationsDeleterRepository _configurationsDeleterRepository;

        public ConfigurationsDeleterService(IConfigurationsDeleterRepository configurationsDeleterRepository)
        {
            _configurationsDeleterRepository = configurationsDeleterRepository;
        }

        public async Task UpdateConfiguration(Guid id)
        {
            await _configurationsDeleterRepository.DeleteConfiguration(id);
        }
    }
}

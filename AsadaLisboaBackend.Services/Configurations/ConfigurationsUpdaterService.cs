using AsadaLisboaBackend.Models.DTOs.Configuration;
using AsadaLisboaBackend.ServiceContracts.Configurations;
using AsadaLisboaBackend.RepositoryContracts.Configurations;

namespace AsadaLisboaBackend.Services.Configurations
{
    public class ConfigurationsUpdaterService : IConfigurationsUpdaterService
    {
        private readonly IConfigurationsUpdaterRepository _configurationsUpdaterRepository;

        public ConfigurationsUpdaterService(IConfigurationsUpdaterRepository configurationsUpdaterRepository)
        {
            _configurationsUpdaterRepository = configurationsUpdaterRepository;
        }

        public async Task<ConfigurationResponseDTO> UpdateConfiguration(Guid id, ConfigurationsRequestDTO configurationRequestDTO)
        {
            return (await _configurationsUpdaterRepository.UpdateConfiguration(id, configurationRequestDTO))
                .ToConfigurationResponseDTO();
        }
    }
}

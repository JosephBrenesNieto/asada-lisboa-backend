using AsadaLisboaBackend.Models.DTOs.Configuration;
using AsadaLisboaBackend.ServiceContracts.Configurations;
using AsadaLisboaBackend.RepositoryContracts.Configurations;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Configurations
{
    public class ConfigurationsUpdaterService : IConfigurationsUpdaterService
    {
        private readonly IConfigurationsUpdaterRepository _configurationsUpdaterRepository;
        private readonly ILogger<ConfigurationsUpdaterService> _logger;

        public ConfigurationsUpdaterService(IConfigurationsUpdaterRepository configurationsUpdaterRepository, ILogger<ConfigurationsUpdaterService> logger)
        {
            _configurationsUpdaterRepository = configurationsUpdaterRepository;            _logger = logger;

        }

        public async Task<ConfigurationResponseDTO> UpdateConfiguration(Guid id, ConfigurationsRequestDTO configurationRequestDTO)
        {
           var result = await _configurationsUpdaterRepository.UpdateConfiguration(id, configurationRequestDTO);

            if (result = null){
                _logger.LogWarning("No se encontró configuración para actualizar con Id: {Id}", id);
            }

            _logger.LogInformation("Actualización exitosa de configuración con Id: {Id}", id);

            return  result.ToConfigurationResponseDTO();
        }
    }
}

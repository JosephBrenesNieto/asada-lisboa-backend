using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DTOs.Configuration;
using AsadaLisboaBackend.ServiceContracts.Configurations;
using AsadaLisboaBackend.RepositoryContracts.Configurations;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Configurations
{
    public class ConfigurationsAdderService : IConfigurationsAdderService
    {
        private readonly IConfigurationsAdderRepository _configurationsAdderRepository;
        private readonly ILogger<ConfigurationsAdderService> _logger;

        public ConfigurationsAdderService(IConfigurationsAdderRepository configurationsAdderRepository, ILogger<ConfigurationsAdderService> logger)
        {
            _configurationsAdderRepository = configurationsAdderRepository;
            _logger = logger;
        }

        public async Task<ConfigurationResponseDTO> CreateConfiguration(ConfigurationsRequestDTO configurationRequestDTO)
        {
            try
             {
                var visualSetting = new VisualSetting()
                {
                    Order = configurationRequestDTO.Order,
                    Value = configurationRequestDTO.Value,
                    SettingType = configurationRequestDTO.SettingType,
                };

               var result = (await _configurationsAdderRepository.CreateConfiguration(visualSetting));

                _logger.LogInformation(
                   "Configuración creada exitosamente. Tipo: {SettingType}, Orden: {Order}",
                   configurationRequestDTO.SettingType,
                   configurationRequestDTO.Order
               );
                return result.ToConfigurationResponseDTO();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error al crear configuración. Tipo: {SettingType}, Orden: {Order}",
                    configurationRequestDTO.SettingType,
                    configurationRequestDTO.Order
                );
                throw;
            }
        }
    }
}

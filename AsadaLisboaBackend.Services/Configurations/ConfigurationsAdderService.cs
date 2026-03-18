using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DTOs.Configuration;
using AsadaLisboaBackend.ServiceContracts.Configurations;
using AsadaLisboaBackend.RepositoryContracts.Configurations;

namespace AsadaLisboaBackend.Services.Configurations
{
    public class ConfigurationsAdderService : IConfigurationsAdderService
    {
        private readonly IConfigurationsAdderRepository _configurationsAdderRepository;

        public ConfigurationsAdderService(IConfigurationsAdderRepository configurationsAdderRepository)
        {
            _configurationsAdderRepository = configurationsAdderRepository;
        }

        public async Task<ConfigurationResponseDTO> CreateConfiguration(ConfigurationsRequestDTO configurationRequestDTO)
        {
            var visualSetting = new VisualSetting()
            {
                Order = configurationRequestDTO.Order,
                Value = configurationRequestDTO.Value,
                SettingType = configurationRequestDTO.SettingType,
            };

            return (await _configurationsAdderRepository.CreateConfiguration(visualSetting))
                .ToConfigurationResponseDTO();
        }
    }
}

using AsadaLisboaBackend.Models.DTOs.Configuration;

namespace AsadaLisboaBackend.ServiceContracts.Configurations
{
    public interface IConfigurationsAdderService
    {
        public Task<ConfigurationResponseDTO> CreateConfiguration(ConfigurationsRequestDTO configurationRequestDTO);
    }
}

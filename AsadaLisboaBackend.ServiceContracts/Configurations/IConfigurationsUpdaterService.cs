using AsadaLisboaBackend.Models.DTOs.Configuration;

namespace AsadaLisboaBackend.ServiceContracts.Configurations
{
    public interface IConfigurationsUpdaterService
    {
        public Task<ConfigurationResponseDTO> UpdateConfiguration(Guid id, ConfigurationsRequestDTO configurationsRequestDTO);
    }
}

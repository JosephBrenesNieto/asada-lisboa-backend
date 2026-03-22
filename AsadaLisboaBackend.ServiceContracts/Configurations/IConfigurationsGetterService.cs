using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.Configuration;

namespace AsadaLisboaBackend.ServiceContracts.Configurations
{
    public interface IConfigurationsGetterService
    {
        public Task<PageResponseDTO<ConfigurationResponseDTO>> GetConfigurations(SearchSortRequestDTO searchSortRequestDTO);
    }
}

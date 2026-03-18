using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.Configuration;

namespace AsadaLisboaBackend.RepositoryContracts.Configurations
{
    public interface IConfigurationsGetterRepository
    {
        public Task<PageResponseDTO<ConfigurationResponseDTO>> GetConfigurations(SearchSortRequestDTO searchSortRequestDTO);
    }
}

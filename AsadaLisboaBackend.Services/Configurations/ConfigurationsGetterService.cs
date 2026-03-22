using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.Configuration;
using AsadaLisboaBackend.ServiceContracts.Configurations;
using AsadaLisboaBackend.RepositoryContracts.Configurations;

namespace AsadaLisboaBackend.Services.Configurations
{
    public class ConfigurationsGetterService : IConfigurationsGetterService
    {
        private readonly IConfigurationsGetterRepository _configurationsGetterRepository;

        public ConfigurationsGetterService(IConfigurationsGetterRepository configurationsGetterRepository)
        {
            _configurationsGetterRepository = configurationsGetterRepository;
        }

        public async Task<PageResponseDTO<ConfigurationResponseDTO>> GetConfigurations(SearchSortRequestDTO searchSortRequestDTO)
        {
            searchSortRequestDTO.Offset = (Math.Max(searchSortRequestDTO.Page, 1) - 1) * searchSortRequestDTO.Take;

            return await _configurationsGetterRepository.GetConfigurations(searchSortRequestDTO);
        }
    }
}

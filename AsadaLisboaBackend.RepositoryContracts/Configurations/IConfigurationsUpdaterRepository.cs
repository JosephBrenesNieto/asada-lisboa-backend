using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DTOs.Configuration;

namespace AsadaLisboaBackend.RepositoryContracts.Configurations
{
    public interface IConfigurationsUpdaterRepository
    {
        public Task<VisualSetting> UpdateConfiguration(Guid id, ConfigurationsRequestDTO configurationsRequestDTO);
    }
}

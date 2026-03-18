using AsadaLisboaBackend.Models;

namespace AsadaLisboaBackend.RepositoryContracts.Configurations
{
    public interface IConfigurationsAdderRepository
    {
        public Task<VisualSetting> CreateConfiguration(VisualSetting visualSetting);
    }
}

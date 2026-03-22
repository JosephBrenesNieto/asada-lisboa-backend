using AsadaLisboaBackend.Models;

namespace AsadaLisboaBackend.RepositoryContracts.Configurations
{
    public interface IConfigurationsDeleterRepository
    {
        public Task DeleteConfiguration(Guid id);
    }
}

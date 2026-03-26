using AsadaLisboaBackend.Models;

namespace AsadaLisboaBackend.RepositoryContracts.News
{
    public interface INewsGetterRepository
    {
        public Task<New?> GetNew(Guid id);
    }
}

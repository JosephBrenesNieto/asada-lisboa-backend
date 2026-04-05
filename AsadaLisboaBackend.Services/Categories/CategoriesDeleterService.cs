using Microsoft.Extensions.Logging;
using AsadaLisboaBackend.ServiceContracts.Categories;
using AsadaLisboaBackend.RepositoryContracts.Categories;

namespace AsadaLisboaBackend.Services.Categories
{
    public class CategoriesDeleterService : ICategoriesDeleterService
    {
        private readonly ILogger<CategoriesDeleterService> _logger;
        private readonly ICategoriesDeleterRepository _categoriesDeleterRepository;

        public CategoriesDeleterService(ICategoriesDeleterRepository categoriesDeleterRepository, ILogger<CategoriesDeleterService> logger)
        {
            _logger = logger;
            _categoriesDeleterRepository = categoriesDeleterRepository;
        }

        public async Task DeleteCategory(Guid id)
        {
            await _categoriesDeleterRepository.DeleteCategory(id);
            _logger.LogInformation("Categor ía con id {Id} borrado exitosamente.", id);
        }
    }
}

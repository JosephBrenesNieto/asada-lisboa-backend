using Microsoft.Extensions.Logging;
using AsadaLisboaBackend.Utils;
using AsadaLisboaBackend.ServiceContracts.Categories;
using AsadaLisboaBackend.RepositoryContracts.Categories;
using AsadaLisboaBackend.ServiceContracts.MemoryCaches;

namespace AsadaLisboaBackend.Services.Categories
{
    public class CategoriesDeleterService : ICategoriesDeleterService
    {
        private readonly ILogger<CategoriesDeleterService> _logger;
        private readonly IMemoryCachesService _memoryCachesService;
        private readonly ICategoriesDeleterRepository _categoriesDeleterRepository;

        public CategoriesDeleterService(ICategoriesDeleterRepository categoriesDeleterRepository, ILogger<CategoriesDeleterService> logger, IMemoryCachesService memoryCachesService)
        {
            _logger = logger;
            _memoryCachesService = memoryCachesService;
            _categoriesDeleterRepository = categoriesDeleterRepository;
        }

        public async Task DeleteCategory(Guid id)
        {
            await _categoriesDeleterRepository.DeleteCategory(id);
            _logger.LogInformation("Categor ía con id {Id} borrado exitosamente.", id);

            _memoryCachesService.RemoveById(Constants.CACHE_CATEGORIES, id);
            _memoryCachesService.ChangeVersion(Constants.CACHE_CATEGORIES);
        }
    }
}

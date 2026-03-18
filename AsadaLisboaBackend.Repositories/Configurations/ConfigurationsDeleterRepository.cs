using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.RepositoryContracts.Configurations;

namespace AsadaLisboaBackend.Repositories.Configurations
{
    public class ConfigurationsDeleterRepository : IConfigurationsDeleterRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationsDeleterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteConfiguration(Guid id)
        {
            var affectedRows = await _context.VisualSettings
                .Where(v => v.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows < 1)
                throw new NotFoundException("Error al eliminar la configuración.");
        }
    }
}

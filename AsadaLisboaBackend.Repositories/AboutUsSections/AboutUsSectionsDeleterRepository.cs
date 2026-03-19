using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.RepositoryContracts.AboutUsSections;

namespace AsadaLisboaBackend.Repositories.AboutUsSections
{
    public class AboutUsSectionsDeleterRepository : IAboutUsSectionsDeleterRepository
    {
        private readonly ApplicationDbContext _context;

        public AboutUsSectionsDeleterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAboutUsSection(Guid id)
        {
            var affectedRows = await _context.AboutUsSections
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows < 1)
                throw new NotFoundException("Error al eliminar la sección.");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.RepositoryContracts.News;

namespace AsadaLisboaBackend.Repositories.News
{
    public class NewsGetterRepository : INewsGetterRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsGetterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<New?> GetNew(Guid id)
        {
            return await _context.News
                .AsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}

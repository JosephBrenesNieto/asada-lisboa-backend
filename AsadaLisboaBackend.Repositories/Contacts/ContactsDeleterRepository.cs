using Microsoft.EntityFrameworkCore;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.DatabaseContext;
using AsadaLisboaBackend.RepositoryContracts.Contacts;

namespace AsadaLisboaBackend.Repositories.Contacts
{
    public class ContactsDeleterRepository : IContactsDeleterRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactsDeleterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteContact(Guid id)
        {
            var affectedRows = await _context.Contacts
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows < 1)
                throw new NotFoundException("Error al eliminar el contacto.");
        }
    }
}

using AsadaLisboaBackend.ServiceContracts.Contacts;
using AsadaLisboaBackend.RepositoryContracts.Contacts;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Contacts
{
    public class ContactsDeleterService : IContactsDeleterService
    {
        private readonly IContactsDeleterRepository _contactsDeleterRepository;
        private readonly ILogger<ContactsDeleterService> _logger;

        public ContactsDeleterService(IContactsDeleterRepository contactsDeleterRepository, ILogger<ContactsDeleterService> logger)
        {
            _contactsDeleterRepository = contactsDeleterRepository;
            _logger = logger;
        }

        public async Task DeleteContact(Guid id)
        {
            try { 

                await _contactsDeleterRepository.DeleteContact(id);

                _logger.LogInformation("Contacto con Id: {Id} eliminado exitosamente.", id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminar  contacto con Id: {Id}", id);
                throw;
            }


        }
    }
}

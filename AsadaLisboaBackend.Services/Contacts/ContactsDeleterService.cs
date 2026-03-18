using AsadaLisboaBackend.ServiceContracts.Contacts;
using AsadaLisboaBackend.RepositoryContracts.Contacts;

namespace AsadaLisboaBackend.Services.Contacts
{
    public class ContactsDeleterService : IContactsDeleterService
    {
        private readonly IContactsDeleterRepository _contactsDeleterRepository;

        public ContactsDeleterService(IContactsDeleterRepository contactsDeleterRepository)
        {
            _contactsDeleterRepository = contactsDeleterRepository;
        }

        public async Task DeleteContact(Guid id)
        {
            await _contactsDeleterRepository.DeleteContact(id);
        }
    }
}

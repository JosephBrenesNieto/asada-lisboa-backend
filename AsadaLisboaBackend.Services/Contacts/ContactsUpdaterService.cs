using AsadaLisboaBackend.Models.DTOs.Contact;
using AsadaLisboaBackend.ServiceContracts.Contacts;
using AsadaLisboaBackend.RepositoryContracts.Contacts;

namespace AsadaLisboaBackend.Services.Contacts
{
    public class ContactsUpdaterService : IContactsUpdaterService
    {
        private readonly IContactsUpdaterRepository _contactsUpdaterRepository;

        public ContactsUpdaterService(IContactsUpdaterRepository contactsUpdaterRepository)
        {
            _contactsUpdaterRepository = contactsUpdaterRepository;
        }

        public async Task<ContactResponseDTO> UpdateContact(Guid id, ContactRequestDTO contactsRequestDTO)
        {
            return (await _contactsUpdaterRepository.UpdateContact(id, contactsRequestDTO))
                .ToContactResponseDTO();
        }
    }
}

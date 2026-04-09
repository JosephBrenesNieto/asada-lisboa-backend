using AsadaLisboaBackend.Models.DTOs.Contact;
using AsadaLisboaBackend.ServiceContracts.Contacts;
using AsadaLisboaBackend.RepositoryContracts.Contacts;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Contacts
{
    public class ContactsUpdaterService : IContactsUpdaterService
    {
        private readonly IContactsUpdaterRepository _contactsUpdaterRepository;
        private readonly ILogger<ContactsUpdaterService> _logger;

        public ContactsUpdaterService(IContactsUpdaterRepository contactsUpdaterRepository, ILogger<ContactsUpdaterService> logger)
        {
            _contactsUpdaterRepository = contactsUpdaterRepository;
            _logger = logger;
        }

        public async Task<ContactResponseDTO> UpdateContact(Guid id, ContactRequestDTO contactsRequestDTO)
        {
            var result = (await _contactsUpdaterRepository.UpdateContact(id, contactsRequestDTO));

            if (result = null)
            {
                _logger.LogWarning("No se encontró contacto para actualizar con Id: {Id}", id);
            }

            _logger.LogInformation("Actualización exitosa de contacto con Id: {Id}", id);

            return result.ToContactResponseDTO();
        }
    }
}

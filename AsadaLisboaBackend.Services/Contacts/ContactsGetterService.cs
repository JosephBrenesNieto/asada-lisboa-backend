using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.Contact;
using AsadaLisboaBackend.ServiceContracts.Contacts;
using AsadaLisboaBackend.RepositoryContracts.Contacts;
using Microsoft.Extensions.Logging;

namespace AsadaLisboaBackend.Services.Contacts
{
    public class ContactsGetterService : IContactsGetterService
    {
        private readonly IContactsGetterRepository _contactsGetterRepository;
        private readonly ILogger<ContactsGetterService> _logger;

        public ContactsGetterService(IContactsGetterRepository contactsGetterRepository, ILogger<ContactsGetterService> logger)
        {
            _contactsGetterRepository = contactsGetterRepository;
            _logger = logger;
        }

        public async Task<PageResponseDTO<ContactResponseDTO>> GetContacts(SearchSortRequestDTO searchSortRequestDTO)
        {
            try { 
                  searchSortRequestDTO.Offset = (Math.Max(searchSortRequestDTO.Page, 1) - 1) * searchSortRequestDTO.Take;

              var result = await _contactsGetterRepository.GetContacts(searchSortRequestDTO);

                _logger.LogInformation(
                    "Obtención exitosa de configuración. Página: {Page}, Tamaño: {Take}",
                    searchSortRequestDTO.Page,
                    searchSortRequestDTO.Take
                );

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error al obtener contacto. Página: {Page}, Tamaño: {Take}",
                    searchSortRequestDTO.Page,
                    searchSortRequestDTO.Take
                );
                throw;
            }
        }
    }
}

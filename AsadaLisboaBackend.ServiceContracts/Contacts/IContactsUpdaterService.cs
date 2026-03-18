using AsadaLisboaBackend.Models.DTOs.Contact;

namespace AsadaLisboaBackend.ServiceContracts.Contacts
{
    public interface IContactsUpdaterService
    {
        public Task<ContactResponseDTO> UpdateContact(Guid id, ContactRequestDTO contactRequestDTO);
    }
}

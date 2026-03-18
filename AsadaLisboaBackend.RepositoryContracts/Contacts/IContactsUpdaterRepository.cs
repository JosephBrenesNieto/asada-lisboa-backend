using AsadaLisboaBackend.Models;
using AsadaLisboaBackend.Models.DTOs.Contact;

namespace AsadaLisboaBackend.RepositoryContracts.Contacts
{
    public interface IContactsUpdaterRepository
    {
        public Task<Contact> UpdateContact(Guid id, ContactRequestDTO contactRequestDTO);
    }
}

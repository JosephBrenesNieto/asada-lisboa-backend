using AsadaLisboaBackend.Models.DTOs.Document;

namespace AsadaLisboaBackend.ServiceContracts.Document
{
   public interface IDocumentService
    {
        public Task<DocumentResponseDTO> CreateDocument(DocumentRequestDTO documentRequestDTO);
    }
}

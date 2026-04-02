using AsadaLisboaBackend.Models.DTOs.Shared;
using AsadaLisboaBackend.Models.DTOs.Document;

namespace AsadaLisboaBackend.RepositoryContracts.Documents
{
    public interface IDocumentsGetterRepository
    {
        public Task<PageResponseDTO<DocumentMinimalResponseDTO>> GetDocuments(SearchSortRequestDTO searchSortRequestDTO);
        public Task<Models.Document> GetDocumentBySlug(string slug);
        public Task<Models.Document> GetDocument(Guid id);
    }
}

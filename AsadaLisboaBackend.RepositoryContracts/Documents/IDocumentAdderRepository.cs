using AsadaLisboaBackend.Models;

namespace AsadaLisboaBackend.RepositoryContracts.Documents
{
    public interface IDocumentAdderRepository
    {
        public Task<Document> CreateDocument(Document newDocument);
    }
}

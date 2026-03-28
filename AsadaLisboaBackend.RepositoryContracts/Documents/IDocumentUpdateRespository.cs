
namespace AsadaLisboaBackend.RepositoryContracts.Documents
{
    public interface IDocumentUpdateRespository
    {
        public Task<Models.Document> UpdateDocument(Models.Document document);
    }
}

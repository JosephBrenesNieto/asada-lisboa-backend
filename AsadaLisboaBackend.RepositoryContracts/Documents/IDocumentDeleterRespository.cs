namespace AsadaLisboaBackend.RepositoryContracts.Documents
{
    public interface IDocumentDeleterRespository
    {
        public Task DeleteDocument(Guid id);
    }
}

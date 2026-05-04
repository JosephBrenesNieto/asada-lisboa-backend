using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using AsadaLisboaBackend.Models.DTOs.SearchGlobal;
using AsadaLisboaBackend.ServiceContracts.SearchGlobal;

namespace AsadaLisboaBackend.Services.SearchGlobal
{
    public class SearchGlobalService : ISearchGlobalService
    {
        private readonly ElasticsearchClient _client;

        public SearchGlobalService(ElasticsearchClient client)
        {
            _client = client;
        }

        public async Task<List<SearchGlobalDocument>> Search(string query)
        {
            var response = await _client.SearchAsync<SearchGlobalDocument>(s => s
                .Indices(new[] { "documentos", "imagenes", "noticias" })
                .IgnoreUnavailable(true)
                .Query(q => q
                    .Bool(b => b
                        .Should(
                            sh => sh.MultiMatch(mm => mm
                                .Fields(new[] { "title^3", "description^2" })
                                .Query(query)
                                .Fuzziness("AUTO")
                            ),
                            sh => sh.MultiMatch(mm => mm
                                .Fields(new[] { "title^3", "description^2" })
                                .Query(query)
                                .Type(TextQueryType.PhrasePrefix)
                            )
                        )
                    )
                )
            );

            return response.Documents.ToList();
        }
    }
}

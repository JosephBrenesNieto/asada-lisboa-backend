using Microsoft.EntityFrameworkCore;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace AsadaLisboaBackend.ServicesExtension
{
    public static class ElasticSearchExtension
    {
        public static IServiceCollection ElasticSearchRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["Elasticsearch:Url"];

            var settings = new ElasticsearchClientSettings(new Uri(url))                    
           .DefaultIndex("contenido"); 

            var client = new ElasticsearchClient(settings);

            return services.AddSingleton(client);
        }

    }
}

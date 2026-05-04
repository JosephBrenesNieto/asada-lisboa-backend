using Elastic.Clients.Elasticsearch;

namespace AsadaLisboaBackend.ServicesExtension
{
    /// <summary>
    /// Extension method to ElasticSearch.
    /// </summary>
    public static class ElasticSearchExtension
    {
        /// <summary>
        /// Elastic search registration into DI container.
        /// </summary>
        /// <param name="services">Collection of services.</param>
        /// <param name="configuration">Access to the system configurations.</param>
        /// <returns>List of registered services.</returns>
        public static IServiceCollection ElasticSearchRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(sp =>
            {
                var settings = new ElasticsearchClientSettings(
                    new Uri(configuration["ElasticSearch:Url"]!));

                return new ElasticsearchClient(settings);
            });

            return services;
        }

    }
}

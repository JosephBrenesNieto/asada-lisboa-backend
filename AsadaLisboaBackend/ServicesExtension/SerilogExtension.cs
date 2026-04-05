using Serilog;

namespace AsadaLisboaBackend.ServicesExtension
{
    public static class SerilogExtension
    {
        public static IServiceCollection SerilogRegistration(this IServiceCollection services, ConfigureHostBuilder host)
        {
            host.UseSerilog((context, services, logger) =>
            {
                logger.ReadFrom.Configuration(context.Configuration);
                logger.ReadFrom.Services(services);
            });

            return services;
        }
    }
}

using Asp.Versioning;

namespace AsadaLisboaBackend.ServicesExtension
{
    public static class VersioningExtension
    {
        public static IServiceCollection VersioningRegistration(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                o.ApiVersionReader = new HeaderApiVersionReader("x-version");
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}

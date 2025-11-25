using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MecatolArchives.ApiService.Client.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApiClient(IConfiguration configuration)
        {
            services.AddHttpClient<MecatolArchivesApiClient>(client =>
            {
                client.BaseAddress = new Uri("https+http://apiservice");
            });

            return services;
        }
    }
}

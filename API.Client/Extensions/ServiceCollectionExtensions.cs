using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Client.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Hesketh.MecatolArchives.API.Client.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// The assumption is that you have already configured a IAdminCredentialStore
    /// </summary>
    /// <param name="serviceCollection">The application services you are adding too</param>
    /// <param name="apiAddress">The address of the Mecatol Archives API Server</param>
    /// <returns></returns>
    public static IServiceCollection AddClients(this IServiceCollection serviceCollection, Uri apiAddress)
    {
        serviceCollection.AddTransient<IAuthHeaderProvider, BasicAuthHeaderProvider>();

        serviceCollection.AddHttpClient<AdminClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<ColourClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<ExpansionClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<FactionClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<PersonClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<VariantClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<PlayClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<StatisticClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<AchievementClient>(client => { client.BaseAddress = apiAddress; });

        return serviceCollection;
    }
}
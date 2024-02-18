using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Client.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Hesketh.MecatolArchives.API.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClients(this IServiceCollection serviceCollection, Uri apiAddress)
    {
        var basicAuthService = new BasicAuthService();
        serviceCollection.AddSingleton<IAuthHeaderProvider>(basicAuthService);
        serviceCollection.AddSingleton<IAdminCredentialStore>(basicAuthService);

        serviceCollection.AddHttpClient<AdminClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<ColourClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<ExpansionClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<FactionClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<PersonClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<VariantClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<PlayClient>(client => { client.BaseAddress = apiAddress; });
        serviceCollection.AddHttpClient<StatisticClient>(client => { client.BaseAddress = apiAddress; });

        return serviceCollection;
    }
}
using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class StatisticClient : Client
{
    public StatisticClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider)
    {
    }

    public async Task<Statistics> GetFactionStatistics()
    {
        return await GetAsync<Statistics>("stats/factions");
    }

    public async Task<Statistics> GetPersonFactionStatistics(Guid personIdentifier)
    {
        return await GetAsync<Statistics>($"stats/factions/person={personIdentifier}");
    }

    public async Task<Statistics> GetPeopleStatistics()
    {
        return await GetAsync<Statistics>("stats/people");
    }

    public async Task<Statistics> GetFactionPeopleStatistics(Guid factionIdentifier)
    {
        return await GetAsync<Statistics>($"stats/people/faction={factionIdentifier}");
    }

}
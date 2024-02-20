using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class FactionClient : EntityClient<Faction, Faction, Post.Faction>
{
    public FactionClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider,
        "factions")
    {
    }
}
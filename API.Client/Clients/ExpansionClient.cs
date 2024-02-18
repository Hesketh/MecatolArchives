using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class ExpansionClient : EntityClient<Expansion, Expansion, Post.Expansion>
{
    public ExpansionClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider,
        "expansions")
    {
    }
}
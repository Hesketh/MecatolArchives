using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class ColourClient : EntityClient<Colour, Colour, Post.Colour>
{
    public ColourClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider,
        "colours")
    {
    }
}
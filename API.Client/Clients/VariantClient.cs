using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class VariantClient : EntityClient<Variant, Variant, Post.Variant>
{
    public VariantClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider,
        "variants")
    {
    }
}
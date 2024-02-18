using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class PersonClient : EntityClient<Person, Person, Post.Person>
{
    public PersonClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider,
        "people")
    {
    }
}
using System.Net.Http.Headers;
using System.Text;

namespace Hesketh.MecatolArchives.API.Client.Auth;

public class BasicAuthHeaderProvider(IAdminCredentialStore credentialStore) : IAuthHeaderProvider
{
    private readonly IAdminCredentialStore _credentialStore = credentialStore;

    public AuthenticationHeaderValue GetHeader()
    {
        return new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_credentialStore.Username}:{_credentialStore.Password}")));
    }
}
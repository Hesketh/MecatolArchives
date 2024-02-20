using System.Net.Http.Headers;
using System.Text;

namespace Hesketh.MecatolArchives.API.Client.Auth;

public class BasicAuthHeaderProvider(IAdminCredentialStore credentialStore) : IAuthHeaderProvider
{
    public async Task<AuthenticationHeaderValue> GetHeaderAsync()
    {
        var details = await credentialStore.GetDetailsAsync();
        return new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"{details.Username}:{details.Password}")));
    }
}
using System.Net.Http.Headers;
using System.Text;

namespace Hesketh.MecatolArchives.API.Client.Auth;

public class BasicAuthService : IAuthHeaderProvider, IAdminCredentialStore
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Set => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

    public AuthenticationHeaderValue GetHeader()
    {
        return new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Username}:{Password}")));
    }
}
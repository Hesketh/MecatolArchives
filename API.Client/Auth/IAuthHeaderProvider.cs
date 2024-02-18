using System.Net.Http.Headers;

namespace Hesketh.MecatolArchives.API.Client.Auth;

public interface IAuthHeaderProvider
{
    AuthenticationHeaderValue GetHeader();
}
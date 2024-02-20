namespace Hesketh.MecatolArchives.API.Auth;

public interface IBasicAuthenticationService
{
    bool Authenticate(string username, string password);
}
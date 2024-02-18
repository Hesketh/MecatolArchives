namespace BookOfNuffle.WebAPI.Auth;

public interface IBasicAuthenticationService
{
    bool Authenticate(string username, string password);
}
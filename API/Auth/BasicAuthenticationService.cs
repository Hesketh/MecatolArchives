using Microsoft.Extensions.Options;

namespace BookOfNuffle.WebAPI.Auth;

public class BasicAuthenticationService : IBasicAuthenticationService
{
    private readonly AdminAccountOptions _adminAccountOptions;

    public BasicAuthenticationService(IOptions<AdminAccountOptions> adminAccountOptions)
    {
        _adminAccountOptions = adminAccountOptions.Value;
        _adminAccountOptions.Validate();
    }

    public bool Authenticate(string username, string password)
    {
        var userMatch = _adminAccountOptions.Accounts.FirstOrDefault(x =>
            x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        if (userMatch == null)
            return false;

        if (userMatch.Password != password)
            return false;

        return true;
    }
}
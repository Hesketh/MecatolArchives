using Microsoft.Extensions.Options;

namespace Hesketh.MecatolArchives.API.Auth;

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
        if (_adminAccountOptions.Account == null)
            return false;
        
        if (!_adminAccountOptions.Account.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase))
            return false;

        if (!_adminAccountOptions.Account.Password.Equals(password, StringComparison.InvariantCulture))
            return false;

        return true;
    }
}
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace BookOfNuffle.WebAPI.Auth;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IBasicAuthenticationService _authenticationService;

    public BasicAuthenticationHandler(
        IBasicAuthenticationService authenticationService,
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) :
        base(options, logger, encoder)
    {
        _authenticationService = authenticationService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authorizationHeader = Request.Headers["Authorization"].ToString();
        if (authorizationHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
        {
            var token = authorizationHeader.Substring("Basic ".Length).Trim();
            var credentialsAsEncodedString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialsAsEncodedString.Split(':');
            if (_authenticationService.Authenticate(credentials[0], credentials[1]))
            {
                var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Admin") };
                var identity = new ClaimsIdentity(claims, "Basic");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return await Task.FromResult(
                    AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
            }
        }

        Response.StatusCode = 401;
        Response.Headers.Append("WWW-Authenticate", "Basic realm=\"joydipkanjilal.com\"");
        return await Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
    }
}
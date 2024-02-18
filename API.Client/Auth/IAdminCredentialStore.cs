namespace Hesketh.MecatolArchives.API.Client.Auth;

public interface IAdminCredentialStore
{
    public string Username { get; set; }
    public string Password { get; set; }

    public bool Set { get; }
}
namespace Hesketh.MecatolArchives.API.Client.Auth;

public interface IAdminCredentialStore
{
    Task SetDetailsAsync(string username, string password);
    Task<(string Username, string Password)> GetDetailsAsync();
    Task<bool> AreDetailsSet();
    Task ResetAsync();
}
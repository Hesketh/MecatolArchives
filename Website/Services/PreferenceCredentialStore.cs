using Hesketh.MecatolArchives.API.Client.Auth;

namespace Hesketh.MecatolArchives.Website.Services;

public class PreferenceCredentialStore(IPreferenceStore preferenceStore) : IAdminCredentialStore
{
    private const string UsernamePreference = "Username";
    private const string PasswordPreference = "Password";
    
    public async Task SetDetailsAsync(string username, string password)
    {
        await preferenceStore.SetPreferenceAsync(UsernamePreference, username).ConfigureAwait(false);
        await preferenceStore.SetPreferenceAsync(PasswordPreference, password).ConfigureAwait(false);
    }

    public async Task<(string Username, string Password)> GetDetailsAsync()
    {
        var username = await preferenceStore.GetPreferenceAsync(UsernamePreference, string.Empty).ConfigureAwait(false);
        var password = await preferenceStore.GetPreferenceAsync(PasswordPreference, string.Empty).ConfigureAwait(false);

        return (username, password);
    }

    public async Task<bool> AreDetailsSet()
    {
        var details = await GetDetailsAsync();
        return !string.IsNullOrEmpty(details.Password) && !string.IsNullOrEmpty(details.Username);
    }

    public async Task ResetAsync()
    {
        await SetDetailsAsync(string.Empty, string.Empty);
    }

    public bool IsSet
    {
        get
        {
            var task = Task.Run(() => preferenceStore.GetPreferenceAsync(UsernamePreference, string.Empty));
            task.ConfigureAwait(false);
            task.RunSynchronously();
            return !string.IsNullOrEmpty(task.Result);
        }
    }
}
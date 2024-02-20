using Hesketh.MecatolArchives.API.Client.Auth;

namespace Hesketh.MecatolArchives.Website.Services;

public class PreferenceCredentialStore(IPreferenceStore preferenceStore) : IAdminCredentialStore
{
    public string Username
    {
        get => preferenceStore.GetPreference(nameof(Username), string.Empty);
        set => preferenceStore.SetPreference(nameof(Username), value);
    }
    
    public string Password
    {
        get => preferenceStore.GetPreference(nameof(Password), string.Empty);
        set => preferenceStore.SetPreference(nameof(Password), value);
    }
}
using Blazored.LocalStorage;

namespace Hesketh.MecatolArchives.Website.Services;

public class CookiePreferenceStore : IPreferenceStore
{
    private readonly ILocalStorageService _localStorageService;

    public CookiePreferenceStore(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<T> GetPreferenceAsync<T>(string key, T defaultValue)
    {
        return await _localStorageService.ContainKeyAsync(key).ConfigureAwait(false)
            ? await _localStorageService.GetItemAsync<T>(key).ConfigureAwait(false) ?? defaultValue
            : defaultValue;
    }

    public async Task SetPreferenceAsync<T>(string key, T value)
    {
        await _localStorageService.SetItemAsync(key, value).ConfigureAwait(false);
    }
}
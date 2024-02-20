using Blazored.LocalStorage;

namespace Hesketh.MecatolArchives.Website.Services;

public class CookiePreferenceStore : IPreferenceStore
{
    private readonly ILocalStorageService _localStorageService;

    public CookiePreferenceStore(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public T GetPreference<T>(string key, T defaultValue)
    {
        var task = GetPreferenceAsync(key, defaultValue);
        task.RunSynchronously();
        return task.Result;
    }

    public void SetPreference<T>(string key, T value)
    {
        var task = SetPreferenceAsync(key, value);
        task.RunSynchronously();
    }

    public async Task<T> GetPreferenceAsync<T>(string key, T defaultValue)
    {
        return await _localStorageService.ContainKeyAsync(key)
            ? await _localStorageService.GetItemAsync<T>(key) ?? defaultValue
            : defaultValue;
    }

    public async Task SetPreferenceAsync<T>(string key, T value)
    {
        await _localStorageService.SetItemAsync(key, value);
    }
}
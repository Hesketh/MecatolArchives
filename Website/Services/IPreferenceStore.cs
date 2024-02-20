namespace Hesketh.MecatolArchives.Website.Services;

public interface IPreferenceStore
{
    T GetPreference<T>(string key, T defaultValue);
    void SetPreference<T>(string key, T value);
    Task<T> GetPreferenceAsync<T>(string key, T defaultValue);
    Task SetPreferenceAsync<T>(string key, T value);
}
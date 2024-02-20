namespace Hesketh.MecatolArchives.Website.Services;

public interface IPreferenceStore
{
    Task<T> GetPreferenceAsync<T>(string key, T defaultValue);
    Task SetPreferenceAsync<T>(string key, T value);
}
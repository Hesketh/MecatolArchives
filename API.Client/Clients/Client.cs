using System.Net.Http.Json;
using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public abstract class Client
{
    protected Client(HttpClient client, IAuthHeaderProvider authHeaderProvider)
    {
        HttpClient = client;
        AuthHeaderProvider = authHeaderProvider;
    }

    protected HttpClient HttpClient { get; }
    public IAuthHeaderProvider AuthHeaderProvider { get; }

    protected async Task<TTransfer> PostAsync<TTransfer, TPost>(string endpoint, TPost entity) where TTransfer : IEntity
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
        requestMessage.Headers.Authorization = await AuthHeaderProvider.GetHeaderAsync();
        requestMessage.Content = JsonContent.Create(entity);

        using var response = await HttpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TTransfer>()
                      ?? throw new InvalidOperationException("Expected valid JSON response from request");

        return content;
    }

    protected async Task PostAsync<TPostType>(string endpoint, TPostType content)
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
        requestMessage.Headers.Authorization = await AuthHeaderProvider.GetHeaderAsync();
        requestMessage.Content = JsonContent.Create(content);

        using var response = await HttpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
    }

    protected async Task<TTransfer> PutAsync<TTransfer, TPut>(string endpoint, TPut entity)
        where TTransfer : IEntity
        where TPut : IEntity
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Put, endpoint);
        requestMessage.Headers.Authorization = await AuthHeaderProvider.GetHeaderAsync();
        requestMessage.Content = JsonContent.Create(entity);

        using var response = await HttpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TTransfer>()
                      ?? throw new InvalidOperationException("Expected valid JSON response from request");

        return content;
    }

    protected async Task DeleteAsync(string endpoint)
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, endpoint);
        requestMessage.Headers.Authorization = await AuthHeaderProvider.GetHeaderAsync();

        using var response = await HttpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
    }

    protected async Task<TTransfer> GetAsync<TTransfer>(string endpoint)
    {
        using var response = await HttpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TTransfer>()
                      ?? throw new InvalidOperationException("Expected valid JSON response from request");

        return content;
    }

    protected async Task<IEnumerable<TTransfer>> GetAllAsync<TTransfer>(string endpoint)
    {
        using var response = await HttpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<IEnumerable<TTransfer>>()
                      ?? throw new InvalidOperationException("Expected valid JSON response from request");

        return content;
    }
}
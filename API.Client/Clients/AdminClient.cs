using System.Net.Http.Json;
using Hesketh.MecatolArchives.API.Client.Auth;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class AdminClient : Client
{
    public AdminClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider)
    {
    }

    public async Task<bool> Confirm()
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "admin");
        requestMessage.Headers.Authorization = await AuthHeaderProvider.GetHeaderAsync();

        using var response = await HttpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<bool>();
        return content;
    }
}
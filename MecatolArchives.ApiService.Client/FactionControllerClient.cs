using System.Net.Http.Json;
using System.Text.Json;
using MecatolArchives.ApiService.Client.Extensions;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.ApiService.Client;

public sealed class FactionControllerClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
{
    public async Task<Faction> CreateAsync(FactionCreateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PostAsync($"/api/factions", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Faction>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Faction> ReadAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/factions/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Faction>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<QueriedCollection<Faction>> ReadAsync(QueryParameters query, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/factions{query.ToQueryString()}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<QueriedCollection<Faction>>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Faction> UpdateAsync(Guid identifier, FactionCreateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PostAsync($"/api/factions/{identifier}", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Faction>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task DeleteAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/api/factions/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
using MecatolArchives.Domain.Dto;
using System.Net.Http.Json;
using System.Text.Json;
using MecatolArchives.ApiService.Client.Extensions;

namespace MecatolArchives.ApiService.Client;

public sealed class ContentControllerClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
{
    public async Task<Content> CreateAsync(ContentCreateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PostAsync($"/api/contents", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Content>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Content> ReadAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/contents/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Content>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<QueriedCollection<Content>> ReadAsync(QueryParameters query, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/contents{query.ToQueryString()}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<QueriedCollection<Content>>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Content> UpdateAsync(Guid identifier, ContentCreateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PostAsync($"/api/contents/{identifier}", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Content>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task DeleteAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/api/contents/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
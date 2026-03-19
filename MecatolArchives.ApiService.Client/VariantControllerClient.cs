using System.Net.Http.Json;
using System.Text.Json;
using MecatolArchives.ApiService.Client.Extensions;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.ApiService.Client;

public sealed class VariantControllerClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
{
    public async Task<Variant> CreateAsync(VariantCreateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PostAsync($"/api/variants", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Variant>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Variant> ReadAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/variants/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Variant>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<QueriedCollection<Variant>> ReadAsync(QueryParameters query, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/variants{query.ToQueryString()}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<QueriedCollection<Variant>>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Variant> UpdateAsync(Guid identifier, VariantUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PutAsync($"/api/variants/{identifier}", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Variant>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task DeleteAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/api/variants/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
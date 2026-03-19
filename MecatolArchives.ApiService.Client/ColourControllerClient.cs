using MecatolArchives.Domain.Dto;
using System.Net.Http.Json;
using System.Text.Json;
using MecatolArchives.ApiService.Client.Extensions;

namespace MecatolArchives.ApiService.Client;

public sealed class ColourControllerClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
{
    public async Task<Colour> CreateAsync(ColourCreateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PostAsync($"/api/colours", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Colour>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Colour> ReadAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/colours/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Colour>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<QueriedCollection<Colour>> ReadAsync(QueryParameters query, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/colours{query.ToQueryString()}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<QueriedCollection<Colour>>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Colour> UpdateAsync(Guid identifier, ColourUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PutAsync($"/api/colours/{identifier}", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Colour>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task DeleteAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/api/colours/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}

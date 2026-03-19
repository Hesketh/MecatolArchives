using MecatolArchives.Domain.Dto;
using System.Net.Http.Json;
using System.Text.Json;
using MecatolArchives.ApiService.Client.Extensions;

namespace MecatolArchives.ApiService.Client;

public sealed class PersonControllerClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
{
    public async Task<Person> CreateAsync(PersonCreateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PostAsync($"/api/persons", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Person>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Person> ReadAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/persons/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Person>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<QueriedCollection<Person>> ReadAsync(QueryParameters query, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/persons{query.ToQueryString()}", cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<QueriedCollection<Person>>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task<Person> UpdateAsync(Guid identifier, PersonUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var requestContent = JsonContent.Create(request);
        var response = await httpClient.PutAsync($"/api/persons/{identifier}", requestContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<Person>(jsonOptions, cancellationToken);
        return content ?? throw new NullReferenceException();
    }

    public async Task DeleteAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"/api/persons/{identifier}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}

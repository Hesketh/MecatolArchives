using MecatolArchives.Domain.Dto;
using System.Net.Http.Json;
using System.Text.Json;
using MecatolArchives.ApiService.Client.Extensions;

namespace MecatolArchives.ApiService.Client
{
    public sealed class ColourControllerClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
    {
        public async Task<Colour> CreateColourAsync(CreateColourRequest request, CancellationToken cancellationToken = default)
        {
            var requestContent =    JsonContent.Create(request);
            var response = await httpClient.PostAsync($"/api/colours", requestContent, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<Colour>(jsonOptions, cancellationToken);
            return content ?? throw new NullReferenceException();
        }

        public async Task<Colour> ReadColourAsync(Guid identifier, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/api/colours/{identifier}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<Colour>(jsonOptions, cancellationToken);
            return content ?? throw new NullReferenceException();
        }

        public async Task<QueriedCollection<Colour>> ReadColoursAsync(QueryParameters query, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/api/colours{query.ToQueryString()}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<QueriedCollection<Colour>>(jsonOptions, cancellationToken);
            return content ?? throw new NullReferenceException();
        }

        public async Task<Colour> UpdateColourAsync(Guid identifier, CreateColourRequest request, CancellationToken cancellationToken = default)
        {
            var requestContent = JsonContent.Create(request);
            var response = await httpClient.PostAsync($"/api/colours/{identifier}", requestContent, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<Colour>(jsonOptions, cancellationToken);
            return content ?? throw new NullReferenceException();
        }

        public async Task DeleteColourAsync(Guid identifier, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"/api/colours/{identifier}", cancellationToken);
            response.EnsureSuccessStatusCode();
        }
    }
}

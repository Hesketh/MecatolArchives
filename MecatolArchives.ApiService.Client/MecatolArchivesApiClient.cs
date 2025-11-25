using System.Text.Json;

namespace MecatolArchives.ApiService.Client
{
    public sealed class MecatolArchivesApiClient(HttpClient httpClient)
    {
        private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public ColourControllerClient Colours => new(httpClient, JsonOptions);
    }
}

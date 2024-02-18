using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients
{
    public sealed class PlayClient : EntityClient<Play, Put.Play, Post.Play>
    {
        private const string Endpoint = "plays";
        
        public PlayClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider, Endpoint)
        {
        }
        
        public async Task<ICollection<Play>> GetPersonsPlaysAsync(Guid personIdentifier)
        {
            return await GetAsync<ICollection<Play>>($"{Endpoint}/person={personIdentifier}");
        }
    }
}

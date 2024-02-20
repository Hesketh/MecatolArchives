using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public class EntityClient<TTransfer, TPut, TPost> : Client
    where TTransfer : IEntity
    where TPut : IEntity
{
    private readonly string _endpoint;

    public EntityClient(HttpClient client, IAuthHeaderProvider authHeaderProvider, string endpoint) : base(client,
        authHeaderProvider)
    {
        _endpoint = endpoint;
    }

    public async Task<TTransfer> GetAsync(Guid identifier)
    {
        return await GetAsync<TTransfer>($"{_endpoint}/{identifier}");
    }

    public async Task<IEnumerable<TTransfer>> GetAsync()
    {
        return await GetAllAsync<TTransfer>(_endpoint);
    }

    public async Task DeleteAsync(Guid identifier)
    {
        await DeleteAsync($"{_endpoint}/{identifier}");
    }

    public async Task DeleteAsync(TTransfer entity)
    {
        await DeleteAsync(entity.Identifier);
    }

    public async Task<TTransfer> UpdateAsync(TPut entity)
    {
        return await PutAsync<TTransfer, TPut>(_endpoint, entity);
    }

    public async Task<TTransfer> CreateAsync(TPost entity)
    {
        return await PostAsync<TTransfer,TPost>(_endpoint, entity);
    }
}
using Hesketh.MecatolArchives.API.Client.Auth;
using Hesketh.MecatolArchives.API.Data;

namespace Hesketh.MecatolArchives.API.Client.Clients;

public sealed class PersonClient : EntityClient<Person, Put.Person, Post.Person>
{
    public PersonClient(HttpClient client, IAuthHeaderProvider authHeaderProvider) : base(client, authHeaderProvider,
        "people")
    {
    }

    public async Task<ICollection<PersonAchievement>> GetAchievements(Guid personIdentifier)
    {
        return (await GetAllAsync<PersonAchievement>($"people/{personIdentifier}/achievements"))
            .ToList();
    }

    public async Task GrantAchievementAsync(Guid personIdentifier, Guid achievementIdentifier)
    {
        await PostAsync($"people/{personIdentifier}/achievements/{achievementIdentifier}");
    }

    public async Task RevokeAchievementAsync(Guid personIdentifier, Guid achievementIdentifier)
    {
        await DeleteAsync($"people/{personIdentifier}/achievements/{achievementIdentifier}");
    }
}
using MecatolArchives.Domain.Dto;
using System.Drawing;

namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
public sealed class FactionsControllerTest(AppHostFixture appHostFixture)
{
    [Fact]
    public async Task ReadFactions_ReturnsExpectedSeededData()
    {
        var factions = await appHostFixture.ApiClient.Factions.ReadAsync(new QueryParameters(), appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(0, factions.TotalCount);
    }

    [Fact]
    public async Task CreateFaction_ValidFaction_CreatesExpected()
    {
        var faction = await appHostFixture.ApiClient.Factions.CreateAsync(new()
        {
            Name = nameof(CreateFaction_ValidFaction_CreatesExpected),
        }, appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreateFaction_ValidFaction_CreatesExpected), faction.Name);
    }

    [Fact]
    public async Task CreateFaction_InvalidFaction_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var faction = await appHostFixture.ApiClient.Factions.CreateAsync(new()
            {
                Name = null!,
            }, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteFaction_ValidFaction_DeletesExpected()
    {
        var faction = await appHostFixture.ApiClient.Factions.CreateAsync(new()
        {
            Name = nameof(DeleteFaction_ValidFaction_DeletesExpected),
        }, appHostFixture.CancellationToken);

        await appHostFixture.ApiClient.Factions.DeleteAsync(faction.Identifier, appHostFixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>((Func<Task>)(async () =>
        {
            var res = await appHostFixture.ApiClient.Factions.ReadAsync(faction.Identifier, appHostFixture.CancellationToken);
        }));
    }

    [Fact]
    public async Task DeleteFaction_InvalidFaction_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await appHostFixture.ApiClient.Factions.DeleteAsync(guid, appHostFixture.CancellationToken);
    }
}

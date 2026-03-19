namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public sealed class PlaysControllerTest(AppHostFixture appHostFixture)
{
    // Seeded data identifiers
    private static readonly Guid ArborecFactionId = Guid.Parse("11ee6931-58d5-4808-b2c5-e3d4b7bf4343");
    private static readonly Guid BlueColourId = Guid.Parse("B5616B41-2821-4A27-85DC-FA81B899E578");
    private static readonly Guid ProphecyOfKingsId = Guid.Parse("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0");
    private static readonly Guid SetupCompetitiveVariantId = Guid.Parse("7f1c0478-b6c1-4ca6-bc79-78912315e947");

    [Fact, Priority(-10)]
    public async Task ReadPlays_ReturnsEmpty()
    {
        var plays = await appHostFixture.ApiClient.Plays.ReadAsync(new QueryParameters(), appHostFixture.CancellationToken);

        Assert.Equal(0, plays.TotalCount);
    }

    [Fact]
    public async Task CreatePlay_ValidPlay_CreatesExpected()
    {
        var person = await appHostFixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(CreatePlay_ValidPlay_CreatesExpected),
        }, appHostFixture.CancellationToken);

        var play = await appHostFixture.ApiClient.Plays.CreateAsync(new()
        {
            UtcDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            RulesVersion = 1.0,
            PointGoal = 10,
            Map = nameof(CreatePlay_ValidPlay_CreatesExpected),
            Players = new([new()
            {
                Points = 5,
                Winner = true,
                Eliminated = false,
                DraftOrder = 1,
                PersonIdentifier = person.Identifier,
                FactionIdentifier = ArborecFactionId,
                ColourIdentified = BlueColourId,
            }]),
            Expansions = new([ProphecyOfKingsId]),
            Variants = new([SetupCompetitiveVariantId]),
        }, appHostFixture.CancellationToken);

        Assert.Equal(nameof(CreatePlay_ValidPlay_CreatesExpected), play.Map);
        Assert.Equal(10u, play.PointGoal);
        Assert.Equal(1.0, play.RulesVersion);
        Assert.Single(play.Players.Items);
        Assert.Equal(person.Identifier, play.Players.Items[0].Person.Identifier);
        Assert.Equal(ArborecFactionId, play.Players.Items[0].Faction.Identifier);
        Assert.Equal(BlueColourId, play.Players.Items[0].Colour.Identifier);
        Assert.Single(play.Expansions.Items);
        Assert.Equal(ProphecyOfKingsId, play.Expansions.Items[0].Identifier);
        Assert.Single(play.Variants.Items);
        Assert.Equal(SetupCompetitiveVariantId, play.Variants.Items[0].Identifier);
    }

    [Fact]
    public async Task CreatePlay_InvalidPlay_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await appHostFixture.ApiClient.Plays.CreateAsync(new()
            {
                UtcDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                RulesVersion = 1.0,
                PointGoal = 10,
                Players = null!,
                Expansions = new([]),
                Variants = new([]),
            }, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task ReadPlay_ValidPlay_ReturnsExpected()
    {
        var person = await appHostFixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(ReadPlay_ValidPlay_ReturnsExpected),
        }, appHostFixture.CancellationToken);

        var created = await appHostFixture.ApiClient.Plays.CreateAsync(new()
        {
            UtcDate = new DateTime(2024, 6, 15, 0, 0, 0, DateTimeKind.Utc),
            RulesVersion = 2.0,
            PointGoal = 12,
            Players = new([new()
            {
                Points = 12,
                Winner = true,
                Eliminated = false,
                DraftOrder = 1,
                PersonIdentifier = person.Identifier,
                FactionIdentifier = ArborecFactionId,
                ColourIdentified = BlueColourId,
            }]),
            Expansions = new([]),
            Variants = new([]),
        }, appHostFixture.CancellationToken);

        var play = await appHostFixture.ApiClient.Plays.ReadAsync(created.Identifier, appHostFixture.CancellationToken);

        Assert.Equal(created.Identifier, play.Identifier);
        Assert.Equal(2.0, play.RulesVersion);
        Assert.Equal(12u, play.PointGoal);
    }

    [Fact]
    public async Task UpdatePlay_ValidPlay_UpdatesExpected()
    {
        var person = await appHostFixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(UpdatePlay_ValidPlay_UpdatesExpected),
        }, appHostFixture.CancellationToken);

        var created = await appHostFixture.ApiClient.Plays.CreateAsync(new()
        {
            UtcDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            RulesVersion = 1.0,
            PointGoal = 10,
            Players = new([new()
            {
                Points = 0,
                Winner = false,
                Eliminated = false,
                DraftOrder = 1,
                PersonIdentifier = person.Identifier,
                FactionIdentifier = ArborecFactionId,
                ColourIdentified = BlueColourId,
            }]),
            Expansions = new([]),
            Variants = new([]),
        }, appHostFixture.CancellationToken);

        var updated = await appHostFixture.ApiClient.Plays.UpdateAsync(created.Identifier, new()
        {
            PointGoal = 14,
            Map = nameof(UpdatePlay_ValidPlay_UpdatesExpected),
            Variants = new([SetupCompetitiveVariantId]),
        }, appHostFixture.CancellationToken);

        Assert.Equal(14u, updated.PointGoal);
        Assert.Equal(nameof(UpdatePlay_ValidPlay_UpdatesExpected), updated.Map);
        Assert.Single(updated.Variants.Items);
        Assert.Equal(SetupCompetitiveVariantId, updated.Variants.Items[0].Identifier);
    }

    [Fact]
    public async Task DeletePlay_ValidPlay_DeletesExpected()
    {
        var person = await appHostFixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(DeletePlay_ValidPlay_DeletesExpected),
        }, appHostFixture.CancellationToken);

        var play = await appHostFixture.ApiClient.Plays.CreateAsync(new()
        {
            UtcDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            RulesVersion = 1.0,
            PointGoal = 10,
            Players = new([new()
            {
                Points = 0,
                Winner = false,
                Eliminated = false,
                DraftOrder = 1,
                PersonIdentifier = person.Identifier,
                FactionIdentifier = ArborecFactionId,
                ColourIdentified = BlueColourId,
            }]),
            Expansions = new([]),
            Variants = new([]),
        }, appHostFixture.CancellationToken);

        await appHostFixture.ApiClient.Plays.DeleteAsync(play.Identifier, appHostFixture.CancellationToken);

        await Assert.ThrowsAsync<HttpRequestException>((Func<Task>)(async () =>
        {
            await appHostFixture.ApiClient.Plays.ReadAsync(play.Identifier, appHostFixture.CancellationToken);
        }));
    }

    [Fact]
    public async Task DeletePlay_InvalidPlay_DoesNotThrow()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await appHostFixture.ApiClient.Plays.DeleteAsync(guid, appHostFixture.CancellationToken);
    }
}

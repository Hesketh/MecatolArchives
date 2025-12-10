using MessagePack.Formatters;
using System.Drawing;

namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
public sealed class ColoursControllerTest(AppHostFixture appHostFixture)
{
    [Fact]
    public async Task ReadColours_ReturnsExpectedSeededData()
    {
        var colours = await appHostFixture.ApiClient.Colours.ReadAsync((Domain.Dto.QueryParameters)new(), appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(9, colours.TotalCount);

        Assert.Collection(colours.Items.OrderBy(x => x.Name),
            colour => Assert.Equal("_Unknown_", colour.Name),
            colour => Assert.Equal("Black", colour.Name),
            colour => Assert.Equal("Blue", colour.Name),
            colour => Assert.Equal("Green", colour.Name),
            colour => Assert.Equal("Magenta", colour.Name),
            colour => Assert.Equal("Orange", colour.Name),
            colour => Assert.Equal("Purple", colour.Name),
            colour => Assert.Equal("Red", colour.Name),
            colour => Assert.Equal("Yellow", colour.Name)
        );
    }

    [Fact]
    public async Task CreateColour_ValidColour_CreatesExpected()
    {
        var colour = await appHostFixture.ApiClient.Colours.CreateAsync(new()
        {
            Name = nameof(CreateColour_ValidColour_CreatesExpected),
            Hex = "#123456"
        }, appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreateColour_ValidColour_CreatesExpected), colour.Name);
        Assert.Equal("#123456", colour.Hex);
    }

    [Fact]
    public async Task CreateColour_InvalidColour_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var colour = await appHostFixture.ApiClient.Colours.CreateAsync(new()
            {
                Name = null!,
                Hex = null!
            }, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteColour_ValidColour_DeletesExpected()
    {
        var colour = await appHostFixture.ApiClient.Colours.CreateAsync(new()
        {
            Name = nameof(DeleteColour_ValidColour_DeletesExpected),
            Hex = "#123456"
        }, appHostFixture.CancellationToken);

        await appHostFixture.ApiClient.Colours.DeleteAsync(colour.Identifier, appHostFixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var res = await appHostFixture.ApiClient.Colours.ReadAsync(colour.Identifier, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteColour_InvalidColour_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await appHostFixture.ApiClient.Colours.DeleteAsync(guid, appHostFixture.CancellationToken);
    }
}

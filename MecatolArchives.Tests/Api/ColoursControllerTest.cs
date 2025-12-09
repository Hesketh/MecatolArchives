using MessagePack.Formatters;
using System.Drawing;

namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
public sealed class ColoursControllerTest 
{
    private readonly AppHostFixture _fixture;

    public ColoursControllerTest(AppHostFixture appHostFixture)
    {
        _fixture = appHostFixture;
    }

    [Fact]
    public async Task ReadColours_ReturnsExpectedSeededData()
    {
        var colours = await _fixture.ApiClient.Colours.ReadAsync((Domain.Dto.QueryParameters)new(), _fixture.CancellationToken);

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
        var colour = await _fixture.ApiClient.Colours.CreateAsync(new()
        {
            Name = nameof(CreateColour_ValidColour_CreatesExpected),
            Hex = "#123456"
        }, _fixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreateColour_ValidColour_CreatesExpected), colour.Name);
        Assert.Equal("#123456", colour.Hex);
    }

    [Fact]
    public async Task CreateColour_InvalidColour_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var colour = await _fixture.ApiClient.Colours.CreateAsync(new()
            {
                Name = null!,
                Hex = null!
            }, _fixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteColour_ValidColour_DeletesExpected()
    {
        var colour = await _fixture.ApiClient.Colours.CreateAsync(new()
        {
            Name = nameof(DeleteColour_ValidColour_DeletesExpected),
            Hex = "#123456"
        }, _fixture.CancellationToken);

        await _fixture.ApiClient.Colours.DeleteAsync(colour.Identifier, _fixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var res = await _fixture.ApiClient.Colours.ReadAsync(colour.Identifier, _fixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteColour_InvalidColour_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await _fixture.ApiClient.Colours.DeleteAsync(guid, _fixture.CancellationToken);
    }
}

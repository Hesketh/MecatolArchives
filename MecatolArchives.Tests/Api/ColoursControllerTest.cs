using System.Drawing;

namespace MecatolArchives.Tests.Api;

public sealed class ColoursControllerTest : BaseApiControllerTest
{
    [Fact]
    public async Task ReadColours_ReturnsExpectedSeededData()
    {
        var colours = await ApiClient.Colours.ReadColoursAsync(new(), CancellationToken);

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
        var colour = await ApiClient.Colours.CreateColourAsync(new()
        {
            Name = nameof(CreateColour_ValidColour_CreatesExpected),
            Hex = "#123456"
        }, CancellationToken);

        // Assert
        Assert.Equal(nameof(CreateColour_ValidColour_CreatesExpected), colour.Name);
        Assert.Equal("#123456", colour.Hex);
    }

    [Fact]
    public async Task CreateColour_InvalidColour_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var colour = await ApiClient.Colours.CreateColourAsync(new()
            {
                Name = null,
                Hex = null,
            }, CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteColour_ValidColour_DeletesExpected()
    {
        var colour = await ApiClient.Colours.CreateColourAsync(new()
        {
            Name = nameof(DeleteColour_ValidColour_DeletesExpected),
            Hex = "#123456"
        }, CancellationToken);

        await ApiClient.Colours.DeleteColourAsync(colour.Identifier, CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var res = await ApiClient.Colours.ReadColourAsync(colour.Identifier, CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteColour_InvalidColour_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await ApiClient.Colours.DeleteColourAsync(guid, CancellationToken);
    }
}

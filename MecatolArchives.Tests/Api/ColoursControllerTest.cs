namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public sealed class ColoursControllerTest(AppHostFixture appHostFixture)
{
    [Fact, Priority(-10)]
    public async Task ReadColours_ReturnsExpectedSeededData()
    {
        List<Colour> expected =
        [
            new()
            {
                Identifier = Guid.Parse("CBDFDDA9-13BF-4A45-BE5D-0882F6DCBAD8"),
                Hex = string.Empty,
                Name = "_Unknown_"
            },
            new()
            {
                Identifier = Guid.Parse("564F166E-33CB-45CC-BCA6-1B2D16B8BF60"),
                Hex = "#000000",
                Name = "Black"
            },
            new()
            {
                Identifier = Guid.Parse("53BF36A1-669C-41ED-9CED-4FA94BA038EE"),
                Hex = "#FF0000",
                Name = "Red"
            },
            new()
            {
                Identifier = Guid.Parse("E8CA7B27-00CD-4A2A-BC7F-17105E690E2D"),
                Hex = "#008000",
                Name = "Green"
            },
            new()
            {
                Identifier = Guid.Parse("51B6CC96-0E35-48F9-8665-B50BBE3FDB44"),
                Hex = "#FFFF00",
                Name = "Yellow"
            },
            new()
            {
                Identifier = Guid.Parse("A9C3B568-D781-452D-91AE-44B0CC8E7020"),
                Hex = "#800080",
                Name = "Purple"
            },
            new()
            {
                Identifier = Guid.Parse("43C078A5-0561-40F0-8ADC-92AFA32EAEB0"),
                Hex = "#FFA500",
                Name = "Orange"
            },
            new()
            {
                Identifier = Guid.Parse("DACEDA53-E450-4FCE-82D4-EF1CDD312E38"),
                Hex = "#FF00FF",
                Name = "Magenta"
            },
            new()
            {
                Identifier = Guid.Parse("08DDEF19-BD82-4EDA-B245-5E84E8DA38D9"),
                Hex = "#FFFFFF",
                Name = "White"
            },
            new()
            {
                Identifier = Guid.Parse("B5616B41-2821-4A27-85DC-FA81B899E578"),
                Hex = "#0000FF",
                Name = "Blue"
            }
        ];

        var colours = await appHostFixture.ApiClient.Colours.ReadAsync(new QueryParameters { PageSize = expected.Count }, appHostFixture.CancellationToken);

        colours.Items.Should().Contain(expected);
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

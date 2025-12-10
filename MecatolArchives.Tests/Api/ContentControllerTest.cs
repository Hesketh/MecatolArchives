using MecatolArchives.Domain.Dto;
using System.Drawing;

namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
public sealed class ContentsControllerTest(AppHostFixture appHostFixture)
{
    [Fact]
    public async Task ReadContents_ReturnsExpectedSeededData()
    {
        var contents = await appHostFixture.ApiClient.Contents.ReadAsync(new QueryParameters(), appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(9, contents.TotalCount);

        Assert.Collection(contents.Items.OrderBy(x => x.Name),
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
    public async Task CreateContent_ValidContent_CreatesExpected()
    {
        var content = await appHostFixture.ApiClient.Contents.CreateAsync(new()
        {
            Name = nameof(CreateContent_ValidContent_CreatesExpected),
        }, appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreateContent_ValidContent_CreatesExpected), content.Name);
    }

    [Fact]
    public async Task CreateContent_InvalidContent_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var content = await appHostFixture.ApiClient.Contents.CreateAsync(new()
            {
                Name = null!,
            }, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteContent_ValidContent_DeletesExpected()
    {
        var content = await appHostFixture.ApiClient.Contents.CreateAsync(new()
        {
            Name = nameof(DeleteContent_ValidContent_DeletesExpected),
        }, appHostFixture.CancellationToken);

        await appHostFixture.ApiClient.Contents.DeleteAsync(content.Identifier, appHostFixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>((Func<Task>)(async () =>
        {
            var res = await appHostFixture.ApiClient.Contents.ReadAsync(content.Identifier, appHostFixture.CancellationToken);
        }));
    }

    [Fact]
    public async Task DeleteContent_InvalidContent_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await appHostFixture.ApiClient.Contents.DeleteAsync(guid, appHostFixture.CancellationToken);
    }
}

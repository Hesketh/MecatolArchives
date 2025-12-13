namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public sealed class ContentsControllerTest(AppHostFixture appHostFixture)
{
    [Fact, Priority(-10)]
    public async Task ReadContents_ReturnsExpectedSeededData()
    {
        // Arrange
        List<Content> expected =
        [
            new()
            {
                Identifier = Guid.Parse("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0"),
                Name = "Prophecy of Kings"
            },
            new()
            {
                Identifier = Guid.Parse("5615f96a-cce5-41a6-90d8-91aed8cd1645"),
                Name = "Thunder's Edge"
            },
            new()
            {
                Identifier = Guid.Parse("21fbcaf7-ae17-4db7-851a-dc65eb3ba60f"),
                Name = "Codex I: Ordinian"
            },
            new()
            {
                Identifier = Guid.Parse("9420502f-4ef0-4887-add4-3d8a4941016a"),
                Name = "Codex II: Affinity"
            },
            new()
            {
                Identifier = Guid.Parse("1eb732ba-74ac-4993-943e-cd6f3650d310"),
                Name = "Codex III: Vigil"
            },
            new()
            {
                Identifier = Guid.Parse("f77349c8-dc28-424a-b0bc-16057f15d18e"),
                Name = "Codex IV: Liberation"
            },
            new()
            {
                Identifier = Guid.Parse("69996b68-7083-43db-ba63-efffb80df833"),
                Name = "Absol's Agendas & Relics"
            },
            new()
            {
                Identifier = Guid.Parse("7606e091-1f8d-4e58-8d48-8c93dc65b9ad"),
                Name = "Discordant Stars"
            },
            new()
            {
                Identifier = Guid.Parse("dfaeec44-34c8-4bad-94c2-0f69b9e27f87"),
                Name = "Uncharted Space"
            }
        ];

        var contents = await appHostFixture.ApiClient.Contents.ReadAsync(new QueryParameters { PageSize = expected.Count }, appHostFixture.CancellationToken);

        // Assert
        contents.Items.Should().Contain(expected);
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

using MecatolArchives.Domain.Dto;
using System.Drawing;

namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
public sealed class VariantsControllerTest(AppHostFixture appHostFixture)
{
    [Fact]
    public async Task ReadVariants_ReturnsExpectedSeededData()
    {
        var variants = await appHostFixture.ApiClient.Variants.ReadAsync(new QueryParameters(), appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(0, variants.TotalCount);
    }

    [Fact]
    public async Task CreateVariant_ValidVariant_CreatesExpected()
    {
        var variant = await appHostFixture.ApiClient.Variants.CreateAsync(new()
        {
            Name = nameof(CreateVariant_ValidVariant_CreatesExpected),
        }, appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreateVariant_ValidVariant_CreatesExpected), variant.Name);
    }

    [Fact]
    public async Task CreateVariant_InvalidVariant_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var variant = await appHostFixture.ApiClient.Variants.CreateAsync(new()
            {
                Name = null!,
            }, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteVariant_ValidVariant_DeletesExpected()
    {
        var variant = await appHostFixture.ApiClient.Variants.CreateAsync(new()
        {
            Name = nameof(DeleteVariant_ValidVariant_DeletesExpected),
        }, appHostFixture.CancellationToken);

        await appHostFixture.ApiClient.Variants.DeleteAsync(variant.Identifier, appHostFixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>((Func<Task>)(async () =>
        {
            var res = await appHostFixture.ApiClient.Variants.ReadAsync(variant.Identifier, appHostFixture.CancellationToken);
        }));
    }

    [Fact]
    public async Task DeleteVariant_InvalidVariant_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await appHostFixture.ApiClient.Variants.DeleteAsync(guid, appHostFixture.CancellationToken);
    }
}

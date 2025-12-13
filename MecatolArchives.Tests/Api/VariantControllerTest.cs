namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public sealed class VariantsControllerTest(AppHostFixture appHostFixture)
{
    [Fact, Priority(-10)]
    public async Task ReadVariants_ReturnsExpectedSeededData()
    {
        List<Variant> expected = [
            new()
            {
            Identifier = Guid.Parse("7f1c0478-b6c1-4ca6-bc79-78912315e947"),
            Name = "Setup - Competitive"
        }, new()
            {
            Identifier = Guid.Parse("27267f67-8243-4448-b71f-8e6c366e2fc8"),
            Name = "Setup - Cooperative"
        }, new()
            {
            Identifier = Guid.Parse("b28554aa-f0a4-4fd0-adc1-37480b2be570"),
            Name = "Setup - Prebuilt"
        }, new()
            {
            Identifier = Guid.Parse("eaed8375-d283-49ee-9224-93460c91be31"),
            Name = "Setup - Milty"
        }, new()
            {
            Identifier = Guid.Parse("84ee1c98-9b0c-467c-9c6d-b7cdd2e4a9c9"),
            Name = "Mode - Alliance"
        }, new()
            {
            Identifier = Guid.Parse("4c0e5036-8a98-4729-ade2-48fded663369"),
            Name = "Mode - Pax Magnifica"
        }, new()
            {
            Identifier = Guid.Parse("3e2f6313-8387-4010-a5f0-abb6adc5db61"),
            Name = "Rule - No Support Swaps"
        }, new()
            {
            Identifier = Guid.Parse("2367d7be-98ca-4f64-85f1-efb433f9c582"),
            Name = "Rule - Public Objectives Visible"
        }, new()
            {
            Identifier = Guid.Parse("8e0c451b-5137-4dee-b212-7077e8487c23"),
            Name = "Rule - 4/4/4"
        }];

        var variants = await appHostFixture.ApiClient.Variants.ReadAsync(new QueryParameters { PageSize = expected.Count }, appHostFixture.CancellationToken);

        // Assert
        variants.Items.Should().Contain(expected);
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

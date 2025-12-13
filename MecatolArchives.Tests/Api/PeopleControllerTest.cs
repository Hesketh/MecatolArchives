namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
public sealed class PeopleControllerTest(AppHostFixture appHostFixture)
{
    [Fact]
    public async Task ReadPeople_ReturnsExpectedSeededData()
    {
        var people = await appHostFixture.ApiClient.People.ReadAsync(new QueryParameters(), appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(0, people.TotalCount);
    }

    [Fact]
    public async Task CreatePerson_ValidPerson_CreatesExpected()
    {
        var person = await appHostFixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(CreatePerson_ValidPerson_CreatesExpected),
        }, appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreatePerson_ValidPerson_CreatesExpected), person.Name);
    }

    [Fact]
    public async Task CreatePerson_InvalidPerson_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var person = await appHostFixture.ApiClient.People.CreateAsync(new()
            {
                Name = null!,
            }, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeletePerson_ValidPerson_DeletesExpected()
    {
        var person = await appHostFixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(DeletePerson_ValidPerson_DeletesExpected),
        }, appHostFixture.CancellationToken);

        await appHostFixture.ApiClient.People.DeleteAsync(person.Identifier, appHostFixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>((Func<Task>)(async () =>
        {
            var res = await appHostFixture.ApiClient.People.ReadAsync(person.Identifier, appHostFixture.CancellationToken);
        }));
    }

    [Fact]
    public async Task DeletePerson_InvalidPerson_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await appHostFixture.ApiClient.People.DeleteAsync(guid, appHostFixture.CancellationToken);
    }
}

using MecatolArchives.Domain.Dto;
using System.Drawing;

namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
public sealed class PeopleControllerTest
{
    private readonly AppHostFixture _fixture;

    public PeopleControllerTest(AppHostFixture appHostFixture)
    {
        _fixture = appHostFixture;
    }

    [Fact]
    public async Task ReadPeople_ReturnsExpectedSeededData()
    {
        var people = await _fixture.ApiClient.People.ReadAsync(new QueryParameters(), _fixture.CancellationToken);

        // Assert
        Assert.Equal(0, people.TotalCount);
    }

    [Fact]
    public async Task CreatePerson_ValidPerson_CreatesExpected()
    {
        var person = await _fixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(CreatePerson_ValidPerson_CreatesExpected),
        }, _fixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreatePerson_ValidPerson_CreatesExpected), person.Name);
    }

    [Fact]
    public async Task CreatePerson_InvalidPerson_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var person = await _fixture.ApiClient.People.CreateAsync(new()
            {
                Name = null!,
            }, _fixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeletePerson_ValidPerson_DeletesExpected()
    {
        var person = await _fixture.ApiClient.People.CreateAsync(new()
        {
            Name = nameof(DeletePerson_ValidPerson_DeletesExpected),
        }, _fixture.CancellationToken);

        await _fixture.ApiClient.People.DeleteAsync(person.Identifier, _fixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>((Func<Task>)(async () =>
        {
            var res = await _fixture.ApiClient.People.ReadAsync(person.Identifier, _fixture.CancellationToken);
        }));
    }

    [Fact]
    public async Task DeletePerson_InvalidPerson_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await _fixture.ApiClient.People.DeleteAsync(guid, _fixture.CancellationToken);
    }
}

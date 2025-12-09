using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IPersonManagementService
{
    Task<Person> CreateAsync(PersonCreateRequest request);
    Task<QueriedCollection<Person>> ReadAsync(QueryParameters query);
    Task<Person> ReadAsync(Guid identifier);
    Task<Person> UpdateAsync(Guid identifier, PersonUpdateRequest request);
    Task DeleteAsync(Guid identifier);
}

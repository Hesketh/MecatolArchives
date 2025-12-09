using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IFactionManagementService
{
    Task<Faction> CreateAsync(FactionCreateRequest request);
    Task<QueriedCollection<Faction>> ReadAsync(QueryParameters query);
    Task<Faction> ReadAsync(Guid identifier);
    Task<Faction> UpdateAsync(Guid identifier, FactionUpdateRequest request);
    Task DeleteAsync(Guid identifier);
}
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IPlayManagementService
{
    Task<Play> CreateAsync(PlayCreateRequest request);
    Task<QueriedCollection<Play>> ReadAsync(QueryParameters query);
    Task<Play> ReadAsync(Guid identifier);
    Task<Play> UpdateAsync(Guid identifier, PlayUpdateRequest request);
    Task DeleteAsync(Guid identifier);
}

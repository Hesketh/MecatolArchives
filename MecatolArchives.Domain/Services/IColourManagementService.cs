using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IColourManagementService
{
    Task<Colour> CreateAsync(ColourCreateRequest request);
    Task<QueriedCollection<Colour>> ReadAsync(QueryParameters query);
    Task<Colour> ReadAsync(Guid identifier);
    Task<Colour> UpdateAsync(Guid identifier, ColourUpdateRequest request);
    Task DeleteAsync(Guid identifier);
}

using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IColourManagementService
{
    Task<Colour> CreateColourAsync(ColourCreateRequest request);
    Task<QueriedCollection<Colour>> ReadColoursAsync(QueryParameters query);
    Task<Colour> ReadColourAsync(Guid identifier);
    Task<Colour> UpdateColourAsync(Guid identifier, ColourUpdateRequest request);
    Task DeleteColourAsync(Guid identifier);
}

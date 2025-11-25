using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IColourManagementService
{
    Task<Colour> CreateColourAsync(CreateColourRequest request);
    Task<QueriedCollection<Colour>> ReadColoursAsync(QueryParameters query);
    Task<Colour> ReadColourAsync(Guid identifier);
    Task<Colour> UpdateColourAsync(Guid identifier, UpdateColourRequest request);
    Task DeleteColourAsync(Guid identifier);
}

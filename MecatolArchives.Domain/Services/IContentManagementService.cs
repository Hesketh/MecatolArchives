using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IContentManagementService
{
    Task<Content> CreateAsync(ContentCreateRequest request);
    Task<QueriedCollection<Content>> ReadAsync(QueryParameters query);
    Task<Content> ReadAsync(Guid identifier);
    Task<Content> UpdateAsync(Guid identifier, ContentUpdateRequest request);
    Task DeleteAsync(Guid identifier);
}
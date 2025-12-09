using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public interface IVariantManagementService
{
    Task<Variant> CreateAsync(VariantCreateRequest request);
    Task<QueriedCollection<Variant>> ReadAsync(QueryParameters query);
    Task<Variant> ReadAsync(Guid identifier);
    Task<Variant> UpdateAsync(Guid identifier, VariantUpdateRequest request);
    Task DeleteAsync(Guid identifier);
}
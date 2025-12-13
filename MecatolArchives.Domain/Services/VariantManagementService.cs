using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public sealed class VariantManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Variant, Variant, VariantCreateRequest, VariantUpdateRequest>(dbContext), IVariantManagementService
{
    protected override Task<Variant> MapToDto(DataAccess.Models.Variant dbModel)
    {
        return Task.FromResult(new Variant
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name
        });
    }

    protected override Task<DataAccess.Models.Variant> MapToDb(VariantCreateRequest create)
    {
        return Task.FromResult(new DataAccess.Models.Variant
        {
            Identifier = Guid.NewGuid(),
            Name = create.Name
        });
    }

    protected override Task<DataAccess.Models.Variant> MapToDb(DataAccess.Models.Variant dbModel, VariantUpdateRequest update)
    {
        if (update.Name != null)
        {
            dbModel.Name = update.Name;
        }

        return Task.FromResult(dbModel);
    }
}
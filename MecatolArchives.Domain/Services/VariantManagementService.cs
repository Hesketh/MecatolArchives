using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public sealed class VariantManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Variant, Variant, VariantCreateRequest, VariantUpdateRequest>(dbContext), IVariantManagementService
{
    protected override Variant MapToDto(DataAccess.Models.Variant dbModel)
    {
        return new Variant
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name
        };
    }

    protected override DataAccess.Models.Variant MapToDb(VariantCreateRequest create)
    {
        return new DataAccess.Models.Variant
        {
            Identifier = Guid.NewGuid(),
            Name = create.Name
        };
    }

    protected override DataAccess.Models.Variant MapToDb(DataAccess.Models.Variant dbModel, VariantUpdateRequest update)
    {
        if (update.Name != null)
        {
            dbModel.Name = update.Name;
        }

        return dbModel;
    }
}
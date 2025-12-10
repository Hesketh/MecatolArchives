using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public sealed class FactionManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Faction, Faction, FactionCreateRequest, FactionUpdateRequest>(dbContext), IFactionManagementService
{
    protected override Faction MapToDto(DataAccess.Models.Faction dbModel)
    {
        return new Faction
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name,
            Url = dbModel.Url ?? string.Empty
        };
    }

    protected override DataAccess.Models.Faction MapToDb(FactionCreateRequest create)
    {
        return new DataAccess.Models.Faction
        {
            Identifier = Guid.NewGuid(),
            Name = create.Name,
            Url = create.Url
        };
    }

    protected override DataAccess.Models.Faction MapToDb(DataAccess.Models.Faction dbModel, FactionUpdateRequest update)
    {
        if (update.Name != null)
        {
            dbModel.Name = update.Name;
        }

        if (update.Url != null)
        {
            dbModel.Url = update.Url;
        }

        return dbModel;
    }
}
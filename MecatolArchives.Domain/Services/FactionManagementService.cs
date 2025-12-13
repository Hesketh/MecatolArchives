using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace MecatolArchives.Domain.Services;

public sealed class FactionManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Faction, Faction, FactionCreateRequest, FactionUpdateRequest>(dbContext), IFactionManagementService
{
    protected override async Task<Faction> MapToDto(DataAccess.Models.Faction dbModel)
    {
        var factionVariants = await dbContext.FactionVariants
            .Where(x => x.FactionIdentifier == dbModel.Identifier)
            .AsNoTracking()
            .ToListAsync();

        var dto = new Faction
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name,
            Url = dbModel.Url ?? string.Empty
        };

        dto.Variants.AddRange(factionVariants.Select(MapToDto));

        return dto;
    }

    private FactionVariant MapToDto(DataAccess.Models.FactionVariant dbModel)
    {
        return new FactionVariant
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name,
        };
    }

    protected override Task<DataAccess.Models.Faction> MapToDb(FactionCreateRequest create)
    {
        return Task.FromResult(new DataAccess.Models.Faction
        {
            Identifier = Guid.NewGuid(),
            Name = create.Name,
            Url = create.Url
        });
    }

    protected override Task<DataAccess.Models.Faction> MapToDb(DataAccess.Models.Faction dbModel, FactionUpdateRequest update)
    {
        if (update.Name != null)
        {
            dbModel.Name = update.Name;
        }

        if (update.Url != null)
        {
            dbModel.Url = update.Url;
        }

        return Task.FromResult(dbModel);
    }
}
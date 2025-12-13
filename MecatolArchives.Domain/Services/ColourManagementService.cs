using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

internal sealed class ColourManagementService(MecatolArchivesDbContext dbContext)
        : CRUDManagementServiceBase<DataAccess.Models.Colour, Colour, ColourCreateRequest, ColourUpdateRequest>(dbContext), IColourManagementService

{
    protected override Task<Colour> MapToDto(DataAccess.Models.Colour dbModel)
    {
        return Task.FromResult(new Colour
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name,
            Hex = dbModel.Hex
        });
    }

    protected override Task<DataAccess.Models.Colour> MapToDb(ColourCreateRequest create)
    {
        return Task.FromResult(new DataAccess.Models.Colour
        {
            Name = create.Name,
            Hex = create.Hex
        });
    }

    protected override Task<DataAccess.Models.Colour> MapToDb(DataAccess.Models.Colour dbModel, ColourUpdateRequest update)
    {
        if (update.Name != null)
        {
            dbModel.Name = update.Name;
        }

        if (update.Hex != null)
        {
            dbModel.Hex = update.Hex;
        }

        return Task.FromResult(dbModel);
    }
}

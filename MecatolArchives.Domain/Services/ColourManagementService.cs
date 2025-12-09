using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Exceptions;
using MecatolArchives.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MecatolArchives.Domain.Services;

internal sealed class ColourManagementService(MecatolArchivesDbContext dbContext) : IColourManagementService
{
    public async Task<Colour> CreateColourAsync(ColourCreateRequest request)
    {
        var dbModel = new DataAccess.Models.Colour
        {
            Name = request.Name,
            Hex = request.Hex
        };

        dbContext.Colours.Add(dbModel);

        await dbContext.SaveChangesAsync();

        return MapDbModel(dbModel);
    }

    public async Task<QueriedCollection<Colour>> ReadColoursAsync(QueryParameters query)
    {
        var totalCount = await dbContext.Colours.CountAsync();
        var items = await dbContext.Colours.Query(query).ToListAsync();
        var colours = items.Select(MapDbModel).ToList();
        return new QueriedCollection<Colour>
        {
            Items = colours,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalCount = totalCount
        };
    }

    public async Task<Colour> ReadColourAsync(Guid identifier)
    {
        var dbModel = await dbContext.FindAsync<DataAccess.Models.Colour>(identifier);
        if (dbModel is null)
            throw new EntityNotFoundException(typeof(Colour), identifier);

        return MapDbModel(dbModel);
    }

    public async Task<Colour> UpdateColourAsync(Guid identifier, ColourUpdateRequest request)
    {
        var dbModel = await dbContext.FindAsync<DataAccess.Models.Colour>(identifier);
        if (dbModel is null)
            throw new EntityNotFoundException(typeof(Colour), identifier);

        if (request.Name != null)
        {
            dbModel.Name = request.Name;
        }

        if (request.Hex != null)
        {
            dbModel.Hex = request.Hex;
        }

        await dbContext.SaveChangesAsync();

        return MapDbModel(dbModel);
    }

    public async Task DeleteColourAsync(Guid identifier)
    {
        var colour = new DataAccess.Models.Colour { Identifier = identifier };
        dbContext.Attach(colour);
        dbContext.Remove(colour);

        //var dbModel = await dbContext.FindAsync<DataAccess.Models.Colour>(identifier);
        //if (dbModel == null)
            //return;

        //dbContext.Remove(dbModel);

        await dbContext.SaveChangesAsync();
    }

    private Colour MapDbModel(DataAccess.Models.Colour dbModel)
    {
        return new Colour
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name,
            Hex = dbModel.Hex
        };
    }
}

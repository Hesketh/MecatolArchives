using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Exceptions;
using MecatolArchives.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MecatolArchives.Domain.Services;

public abstract class CRUDManagementServiceBase<TDatabase, TDto, TCreateDto, TUpdateDto>(MecatolArchivesDbContext dbContext)
    where TDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TDatabase : class
{
    public async Task<TDto> CreateAsync(TCreateDto request)
    {
        var dbModel = MapToDb(request);

        var set = dbContext.Set<TDatabase>();
        set.Add(dbModel);

        await dbContext.SaveChangesAsync();

        return MapToDto(dbModel);
    }

    public async Task<QueriedCollection<TDto>> ReadAsync(QueryParameters query)
    {
        var set = dbContext.Set<TDatabase>();
        var totalCount = await set.CountAsync();
        var items = await set.Query(query).ToListAsync();
        var contents = items.Select(MapToDto).ToList();

        return new QueriedCollection<TDto>
        {
            Items = contents,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalCount = totalCount
        };
    }

    public async Task<TDto> ReadAsync(Guid identifier)
    {
        var dbModel = await dbContext.FindAsync<TDatabase>(identifier);
        if (dbModel is null)
            throw new EntityNotFoundException(typeof(TDatabase), identifier);

        return MapToDto(dbModel);
    }

    public async Task<TDto> UpdateAsync(Guid identifier, TUpdateDto request)
    {
        var dbModel = await dbContext.FindAsync<TDatabase>(identifier);
        if (dbModel is null)
            throw new EntityNotFoundException(typeof(TDatabase), identifier);

        dbModel = MapToDb(dbModel, request);

        await dbContext.SaveChangesAsync();

        return MapToDto(dbModel);
    }

    public async Task DeleteAsync(Guid identifier)
    {
        var dbModel = await dbContext.FindAsync<TDatabase>(identifier);
        if (dbModel == null)
            return;

        dbContext.Remove(dbModel);

        await dbContext.SaveChangesAsync();
    }

    protected abstract TDto MapToDto(TDatabase dbModel);
    protected abstract TDatabase MapToDb(TCreateDto create);
    protected abstract TDatabase MapToDb(TDatabase dbModel, TUpdateDto update);
}

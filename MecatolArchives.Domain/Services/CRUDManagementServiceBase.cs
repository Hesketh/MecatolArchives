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
        var dbModel = await MapToDb(request);

        var set = dbContext.Set<TDatabase>();
        set.Add(dbModel);

        await dbContext.SaveChangesAsync();

        return await MapToDto(dbModel);
    }

    public async Task<QueriedCollection<TDto>> ReadAsync(QueryParameters query)
    {
        var set = dbContext.Set<TDatabase>();
        var totalCount = await set.CountAsync();
        var items = await set.Query(query).ToListAsync();

        var contents = await MapToDto(items);

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

        return await MapToDto(dbModel);
    }

    public async Task<TDto> UpdateAsync(Guid identifier, TUpdateDto request)
    {
        var dbModel = await dbContext.FindAsync<TDatabase>(identifier);
        if (dbModel is null)
            throw new EntityNotFoundException(typeof(TDatabase), identifier);

        dbModel = await MapToDb(dbModel, request);

        await dbContext.SaveChangesAsync();

        return await MapToDto(dbModel);
    }

    public async Task DeleteAsync(Guid identifier)
    {
        var dbModel = await dbContext.FindAsync<TDatabase>(identifier);
        if (dbModel == null)
            return;

        dbContext.Remove(dbModel);

        await dbContext.SaveChangesAsync();
    }

    protected abstract Task<TDto> MapToDto(TDatabase dbModel);
    protected abstract Task<TDatabase> MapToDb(TCreateDto create);
    protected abstract Task<TDatabase> MapToDb(TDatabase dbModel, TUpdateDto update);

    private async Task<ICollection<TDto>> MapToDto(IEnumerable<TDatabase> dbModels)
    {
        var collection = new List<TDto>();

        foreach (var dbModel in dbModels)
        {
            var dtoModel = await MapToDto(dbModel);
            collection.Add(dtoModel);
        }

        return collection;
    }
}

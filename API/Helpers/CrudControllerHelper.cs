using AutoMapper;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.API.Helpers;

public sealed class CrudControllerHelper<TDatabase, TGet, TPut, TPost> : ControllerBase
    where TDatabase : class, IEntity, INamed
    where TGet : Data.IEntity
    where TPut : Data.IEntity
{
    private readonly MecatolArchivesDbContext _db;
    private readonly IMapper _mapper;

    public CrudControllerHelper(MecatolArchivesDbContext db,
        IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    //[HttpGet("{identifier}")]
    public async Task<ActionResult<TGet>> GetAsync(Guid identifier)
    {
        var res = await _db.Set<TDatabase>().FirstOrDefaultAsync(x => x.Identifier == identifier);
        if (res == null) return NotFound();

        var mapped = _mapper.Map<TGet>(res);
        return Ok(mapped);
    }

    //[HttpGet]
    public async Task<ActionResult<ICollection<TGet>>> GetAsync()
    {
        var res = await _db.Set<TDatabase>()
            .OrderBy(x => x.Name)
            .ToListAsync();
        var mapped = _mapper.Map<ICollection<TGet>>(res);
        return Ok(mapped);
    }

    //[HttpPost]
    public async Task<ActionResult<TGet>> PostAsync(TPost model)
    {
        var entity = _mapper.Map<TDatabase>(model);
        await _db.Set<TDatabase>().AddAsync(entity);
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<TGet>(entity);
        return Ok(mapped);
    }

    //[HttpPut]
    public async Task<ActionResult<TGet>> PutAsync(TPut model)
    {
        var entity = await _db.Set<TDatabase>().FirstOrDefaultAsync(x => x.Identifier == model.Identifier);
        if (entity == null) return NotFound();

        entity = _mapper.Map(model, entity);
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<TGet>(entity);
        return Ok(mapped);
    }

    //[HttpDelete("{identifier}")]
    public async Task<IActionResult> DeleteAsync(Guid identifier)
    {
        var entity = await _db.Set<TDatabase>().FirstOrDefaultAsync(x => x.Identifier == identifier);
        if (entity == null) return NotFound();

        _db.Set<TDatabase>().Remove(entity);
        await _db.SaveChangesAsync();

        return Ok();
    }
}
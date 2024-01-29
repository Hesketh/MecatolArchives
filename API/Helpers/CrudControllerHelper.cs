using AutoMapper;
using Hesketh.MecatolArchives.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.API.Helpers;

public sealed class CrudControllerHelper<TDatabase, TTransfer, TPost> : ControllerBase 
    where TDatabase : class, DBM.IEntity, DBM.INamed
    where TTransfer : DTM.IEntity
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
    public async Task<ActionResult<TTransfer>> GetAsync(Guid identifier)
    {
        var res = await _db.GetDbSet<TDatabase>().FirstOrDefaultAsync(x => x.Identifier == identifier);
        if (res == null) return NotFound();

        var mapped = _mapper.Map<TTransfer>(res);
        return Ok(mapped);
    }

    //[HttpGet]
    public async Task<ActionResult<ICollection<TTransfer>>> GetAsync()
    {
        var res = await _db.GetDbSet<TDatabase>()
            .OrderBy(x => x.Name)
            .ToListAsync();
        var mapped = _mapper.Map<ICollection<TTransfer>>(res);
        return Ok(mapped);
    }

    //[HttpPost]
    public async Task<ActionResult<TTransfer>> PostAsync(TPost model)
    {
        var entity = _mapper.Map<TDatabase>(model);
        await _db.GetDbSet<TDatabase>().AddAsync(entity);
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<TTransfer>(entity);
        return Ok(mapped);
    }

    //[HttpPut]
    public async Task<ActionResult<TTransfer>> PutAsync(TTransfer model)
    {
        var entity = await _db.GetDbSet<TDatabase>().FirstOrDefaultAsync(x => x.Identifier == model.Identifier);
        if (entity == null) return NotFound();

        entity = _mapper.Map(model, entity);
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<TTransfer>(entity);
        return Ok(mapped);
    }

    //[HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid identifier)
    {
        var entity = await _db.GetDbSet<TDatabase>().FirstOrDefaultAsync(x => x.Identifier == identifier);
        if (entity == null) return NotFound();

        _db.GetDbSet<TDatabase>().Remove(entity);
        await _db.SaveChangesAsync();

        return Ok();
    }
}
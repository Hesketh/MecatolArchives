using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("plays")]
[Authorize]
public sealed class PlayController : ControllerBase
{
    private readonly MecatolArchivesDbContext _db;
    private readonly IMapper _mapper;
    private readonly CrudControllerHelper<Play, Data.Play, Data.Put.Play, Data.Post.Play> _crud;

    public PlayController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _crud = new CrudControllerHelper<Play, Data.Play, Data.Put.Play, Data.Post.Play>(db, mapper);
    }

    [HttpGet("{identifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<Data.Play>> Get(Guid identifier)
    {
        var res = await _db.GetDbSet<Play>()
            .Include(x => x.Players).ThenInclude(x => x.Person)
            .Include(x => x.Players).ThenInclude(x => x.Faction)
            .Include(x => x.Players).ThenInclude(x => x.Colour)
            .Include(x => x.Variants)
            .Include(x => x.Expansions)
            .FirstOrDefaultAsync(x => x.Identifier == identifier);
        var mapped = _mapper.Map<Data.Play>(res);
        return Ok(mapped);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Play>>> Get()
    {
        var res = await _db.GetDbSet<Play>()
            .OrderByDescending(x => x.UtcDate)
            .Include(x => x.Players).ThenInclude(x => x.Person)
            .Include(x => x.Players).ThenInclude(x => x.Faction)
            .Include(x => x.Players).ThenInclude(x => x.Colour)
            .Include(x => x.Variants)
            .Include(x => x.Expansions)
            .ToListAsync();
        var mapped = _mapper.Map<ICollection<Data.Play>>(res);
        return Ok(mapped);
    }
    
    [HttpGet("person={personIdentifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Play>>> GetWithPlayer(Guid personIdentifier)
    {
        var res = await _db.GetDbSet<Play>()
            .OrderByDescending(x => x.UtcDate)
            .Include(x => x.Players).ThenInclude(x => x.Person)
            .Include(x => x.Players).ThenInclude(x => x.Faction)
            .Include(x => x.Players).ThenInclude(x => x.Colour)
            .Include(x => x.Variants)
            .Include(x => x.Expansions)
            .Where(x => x.Players.Any(y => y.Person.Identifier == personIdentifier))
            .ToListAsync();
        var mapped = _mapper.Map<ICollection<Data.Play>>(res);
        return Ok(mapped);
    }
    
    [HttpGet("faction={factionIdentifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Play>>> GetWithFaction(Guid factionIdentifier)
    {
        var res = await _db.GetDbSet<Play>()
            .OrderByDescending(x => x.UtcDate)
            .Include(x => x.Players).ThenInclude(x => x.Person)
            .Include(x => x.Players).ThenInclude(x => x.Faction)
            .Include(x => x.Players).ThenInclude(x => x.Colour)
            .Include(x => x.Variants)
            .Include(x => x.Expansions)
            .Where(x => x.Players.Any(y => y.Faction.Identifier == factionIdentifier))
            .ToListAsync();
        var mapped = _mapper.Map<ICollection<Data.Play>>(res);
        return Ok(mapped);
    }

    [HttpPost]
    public async Task<ActionResult<Data.Play>> Post(Data.Post.Play model)
    {
        var entity = _mapper.Map<Play>(model);

        entity.Variants = await _db.Variants.Where(x => model.VariantIdentifiers.Contains(x.Identifier)).ToListAsync();
        if (entity.Variants.Count != model.VariantIdentifiers.Count)
            return NotFound("Variants could not be located");

        entity.Expansions = await _db.Expansions.Where(x => model.ExpansionIdentifiers.Contains(x.Identifier)).ToListAsync();
        if (entity.Expansions.Count != model.ExpansionIdentifiers.Count)
            return NotFound("Expansions could not be located");

        entity.Players = new List<Player>();
        foreach (var playerPost in model.Players)
        {
            var playerEntity = _mapper.Map<Player>(playerPost);
            
            var person = await _db.People.FirstOrDefaultAsync(x => x.Identifier == playerPost.PersonIdentifier);
            if (person == null)
                return NotFound($"Player person could not be found");

            var faction = await _db.Factions.FirstOrDefaultAsync(x => x.Identifier == playerPost.FactionIdentifier);
            if (faction == null)
                return NotFound($"Player person could not be found");

            var colour = await _db.Colours.FirstOrDefaultAsync(x => x.Identifier == playerPost.ColourIdentifier);
            if (colour == null)
                return NotFound($"Player colour could not be found");

            playerEntity.Person = person;
            playerEntity.Faction = faction;
            playerEntity.Colour = colour;

            entity.Players.Add(playerEntity);
            playerEntity.Play = entity;
            await _db.GetDbSet<Player>().AddAsync(playerEntity);
        }

        await _db.GetDbSet<Play>().AddAsync(entity);
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<Data.Play>(entity);
        return Ok(mapped);
    }

    [HttpPut]
    public async Task<ActionResult<Data.Play>> Put(Data.Put.Play model)
    {
        var existingEntity = await _db.GetDbSet<Play>()
            .Include(x => x.Players).ThenInclude(x => x.Person)
            .Include(x => x.Players).ThenInclude(x => x.Faction)
            .Include(x => x.Players).ThenInclude(x => x.Colour)
            .Include(x => x.Variants)
            .Include(x => x.Expansions)
            .FirstOrDefaultAsync(x => x.Identifier == model.Identifier);
        if (existingEntity == null)
            return NotFound("Play could not be located");

        var entity = _mapper.Map(model, existingEntity);

        entity.Variants = await _db.Variants.Where(x => model.VariantIdentifiers.Contains(x.Identifier)).ToListAsync();
        if (entity.Variants.Count != model.VariantIdentifiers.Count)
            return NotFound("Variants could not be located");

        entity.Expansions = await _db.Expansions.Where(x => model.ExpansionIdentifiers.Contains(x.Identifier)).ToListAsync();
        if (entity.Expansions.Count != model.ExpansionIdentifiers.Count)
            return NotFound("Expansions could not be located");
        
        entity.Players.Clear();
        foreach (var playerPost in model.Players)
        {
            var playerEntity = _mapper.Map<Player>(playerPost);

            var person = await _db.People.FirstOrDefaultAsync(x => x.Identifier == playerPost.PersonIdentifier);
            if (person == null)
                return NotFound($"Player person could not be found");

            var faction = await _db.Factions.FirstOrDefaultAsync(x => x.Identifier == playerPost.FactionIdentifier);
            if (faction == null)
                return NotFound($"Player person could not be found");

            var colour = await _db.Colours.FirstOrDefaultAsync(x => x.Identifier == playerPost.ColourIdentifier);
            if (colour == null)
                return NotFound($"Player colour could not be found");

            playerEntity.Person = person;
            playerEntity.Faction = faction;
            playerEntity.Colour = colour;

            entity.Players.Add(playerEntity);
            playerEntity.Play = entity;
            await _db.Players.AddAsync(playerEntity);
        }
        
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<Data.Play>(entity);
        return Ok(mapped);
    }

    [HttpDelete("{identifier}")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        return await _crud.DeleteAsync(identifier);
    }
}
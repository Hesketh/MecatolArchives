using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("people")]
[Authorize]
public sealed class PersonController : ControllerBase
{
    private readonly MecatolArchivesDbContext _db;
    private readonly IMapper _mapper;
    private readonly CrudControllerHelper<Person, Data.Person, Data.Person, Data.Post.Person> _crud;

    public PersonController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _crud = new CrudControllerHelper<Person, Data.Person, Data.Person, Data.Post.Person>(db, mapper);
    }

    [HttpGet("{identifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<Data.Person>> Get(Guid identifier)
    {
        var person = await _db.People.Include(x => x.DefaultColour)
            .FirstOrDefaultAsync(x => x.Identifier == identifier);
        if (person == null)
            return NotFound();

        return _mapper.Map<DTM.Person>(person);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Person>>> Get()
    {
        var res = await _db.GetDbSet<Person>()
            .Include(x => x.DefaultColour)
            .OrderBy(x => x.Name)
            .ToListAsync();
        
        var mapped = _mapper.Map<ICollection<DTM.Person>>(res);
        return Ok(mapped);
    }

    [HttpPost]
    public async Task<ActionResult<Data.Person>> Post(Data.Post.Person model)
    {
        var person = _mapper.Map<DBM.Person>(model);
        if (model.DefaultColourId != null)
        {
            var colour = await _db.Colours.FirstOrDefaultAsync(x => x.Identifier == person.Identifier);
            if (colour == null)
                return NotFound("The colour could not be found");

            person.DefaultColour = colour;
        }
        
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<Data.Person>(person);
        return Ok(mapped);
    }

    [HttpPut]
    public async Task<ActionResult<Data.Person>> Put(DTPut.Person model)
    {
        var person = await _db.People.Include(x => x.DefaultColour)
            .FirstOrDefaultAsync(x => x.Identifier == model.Identifier);
        if (person == null)
            return NotFound();

        _mapper.Map(model, person);
        if (model.DefaultColourId != null)
        {
            var colour = await _db.Colours.FirstOrDefaultAsync(x => x.Identifier == model.DefaultColourId);
            if (colour == null)
                return NotFound("The colour could not be found");

            person.DefaultColour = colour;
        }
        else
        {
            person.DefaultColour = null;
        }
        
        await _db.SaveChangesAsync();

        var mapped = _mapper.Map<Data.Person>(person);
        return Ok(mapped);
    }

    [HttpDelete("{identifier}")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        return await _crud.DeleteAsync(identifier);
    }
}
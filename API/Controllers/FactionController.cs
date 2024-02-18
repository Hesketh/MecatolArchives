using AutoMapper;
using Hesketh.MecatolArchives.API.Data;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Faction = Hesketh.MecatolArchives.DB.Models.Faction;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("factions")]
[Authorize]
public sealed class FactionController : ControllerBase
{
    private readonly MecatolArchivesDbContext _db;
    private readonly IMapper _mapper;
    private readonly CrudControllerHelper<Faction, Data.Faction, Data.Faction, Data.Post.Faction> _crud;

    public FactionController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _crud = new CrudControllerHelper<Faction, Data.Faction, Data.Faction, Data.Post.Faction>(db, mapper);
    }

    [HttpGet("{identifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<Data.Faction>> Get(Guid identifier)
    {
        return await _crud.GetAsync(identifier);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Faction>>> Get()
    {
        return await _crud.GetAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Data.Faction>> Post(Data.Post.Faction model)
    {
        return await _crud.PostAsync(model);
    }

    [HttpPut]
    public async Task<ActionResult<Data.Faction>> Put(Data.Faction model)
    {
        return await _crud.PutAsync(model);
    }

    [HttpDelete("{identifier}")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        return await _crud.DeleteAsync(identifier);
    }
}
using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class FactionController : ControllerBase
{
    private readonly CrudControllerHelper<DBM.Faction, DTM.Faction, DTP.Faction> _crud;

    public FactionController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Faction, Data.Faction, Data.Post.Faction>(db, mapper);
    }

    [HttpGet("{identifier}")]
    public async Task<ActionResult<DTM.Faction>> Get(Guid identifier) => await _crud.GetAsync(identifier);

    [HttpGet]
    public async Task<ActionResult<ICollection<DTM.Faction>>> Get() => await _crud.GetAsync();

    [HttpPost]
    public async Task<ActionResult<DTM.Faction>> Post(DTP.Faction model) => await _crud.PostAsync(model);

    [HttpPut]
    public async Task<ActionResult<DTM.Faction>> Put(DTM.Faction model) => await _crud.PutAsync(model);

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid identifier) => await _crud.DeleteAsync(identifier);
}
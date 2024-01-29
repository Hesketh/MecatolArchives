using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ExpansionController : ControllerBase
{
    private readonly CrudControllerHelper<DBM.Expansion, DTM.Expansion, DTP.Expansion> _crud;

    public ExpansionController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Expansion, Data.Expansion, Data.Post.Expansion>(db, mapper);
    }

    [HttpGet("{identifier}")]
    public async Task<ActionResult<DTM.Expansion>> Get(Guid identifier) => await _crud.GetAsync(identifier);

    [HttpGet]
    public async Task<ActionResult<ICollection<DTM.Expansion>>> Get() => await _crud.GetAsync();

    [HttpPost]
    public async Task<ActionResult<DTM.Expansion>> Post(DTP.Expansion model) => await _crud.PostAsync(model);

    [HttpPut]
    public async Task<ActionResult<DTM.Expansion>> Put(DTM.Expansion model) => await _crud.PutAsync(model);

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid identifier) => await _crud.DeleteAsync(identifier);
}
using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ColourController : ControllerBase
{
    private readonly CrudControllerHelper<DBM.Colour, DTM.Colour, DTP.Colour> _crud;

    public ColourController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Colour, Data.Colour, Data.Post.Colour>(db, mapper);
    }

    [HttpGet("{identifier}")]
    public async Task<ActionResult<DTM.Colour>> Get(Guid identifier) => await _crud.GetAsync(identifier);

    [HttpGet]
    public async Task<ActionResult<ICollection<DTM.Colour>>> Get() => await _crud.GetAsync();

    [HttpPost]
    public async Task<ActionResult<DTM.Colour>> Post(DTP.Colour model) => await _crud.PostAsync(model);

    [HttpPut]
    public async Task<ActionResult<DTM.Colour>> Put(DTM.Colour model) => await _crud.PutAsync(model);

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid identifier) => await _crud.DeleteAsync(identifier);
}
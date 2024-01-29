using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class VariantController : ControllerBase
{
    private readonly CrudControllerHelper<DBM.Variant, DTM.Variant, DTP.Variant> _crud;

    public VariantController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Variant, DTM.Variant, DTP.Variant>(db, mapper);
    }

    [HttpGet("{identifier}")]
    public async Task<ActionResult<DTM.Variant>> Get(Guid identifier) => await _crud.GetAsync(identifier);

    [HttpGet]
    public async Task<ActionResult<ICollection<DTM.Variant>>> Get() => await _crud.GetAsync();

    [HttpPost]
    public async Task<ActionResult<DTM.Variant>> Post(DTP.Variant model) => await _crud.PostAsync(model);

    [HttpPut]
    public async Task<ActionResult<DTM.Variant>> Put(DTM.Variant model) => await _crud.PutAsync(model);

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid identifier) => await _crud.DeleteAsync(identifier);
}
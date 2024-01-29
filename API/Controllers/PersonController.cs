using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class PersonController : ControllerBase
{
    private readonly CrudControllerHelper<DBM.Person, DTM.Person, DTP.Person> _crud;

    public PersonController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Person, Data.Person, Data.Post.Person>(db, mapper);
    }

    [HttpGet("{identifier}")]
    public async Task<ActionResult<DTM.Person>> Get(Guid identifier) => await _crud.GetAsync(identifier);

    [HttpGet]
    public async Task<ActionResult<ICollection<DTM.Person>>> Get() => await _crud.GetAsync();

    [HttpPost]
    public async Task<ActionResult<DTM.Person>> Post(DTP.Person model) => await _crud.PostAsync(model);

    [HttpPut]
    public async Task<ActionResult<DTM.Person>> Put(DTM.Person model) => await _crud.PutAsync(model);

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid identifier) => await _crud.DeleteAsync(identifier);
}
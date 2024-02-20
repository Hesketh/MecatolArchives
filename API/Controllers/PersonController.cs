using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("people")]
[Authorize]
public sealed class PersonController : ControllerBase
{
    private readonly CrudControllerHelper<Person, Data.Person, Data.Person, Data.Post.Person> _crud;

    public PersonController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Person, Data.Person, Data.Person, Data.Post.Person>(db, mapper);
    }

    [HttpGet("{identifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<Data.Person>> Get(Guid identifier)
    {
        return await _crud.GetAsync(identifier);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Person>>> Get()
    {
        return await _crud.GetAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Data.Person>> Post(Data.Post.Person model)
    {
        return await _crud.PostAsync(model);
    }

    [HttpPut]
    public async Task<ActionResult<Data.Person>> Put(Data.Person model)
    {
        return await _crud.PutAsync(model);
    }

    [HttpDelete("{identifier}")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        return await _crud.DeleteAsync(identifier);
    }
}
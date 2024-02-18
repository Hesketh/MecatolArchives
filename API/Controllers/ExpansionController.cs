using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("expansions")]
[Authorize]
public sealed class ExpansionController : ControllerBase
{
    private readonly CrudControllerHelper<Expansion, Data.Expansion, Data.Expansion, Data.Post.Expansion> _crud;

    public ExpansionController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Expansion, Data.Expansion, Data.Expansion, Data.Post.Expansion>(db, mapper);
    }

    [HttpGet("{identifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<Data.Expansion>> Get(Guid identifier)
    {
        return await _crud.GetAsync(identifier);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Expansion>>> Get()
    {
        return await _crud.GetAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Data.Expansion>> Post(Data.Post.Expansion model)
    {
        return await _crud.PostAsync(model);
    }

    [HttpPut]
    public async Task<ActionResult<Data.Expansion>> Put(Data.Expansion model)
    {
        return await _crud.PutAsync(model);
    }

    [HttpDelete("{identifier}")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        return await _crud.DeleteAsync(identifier);
    }
}
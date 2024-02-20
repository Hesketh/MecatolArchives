using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("colours")]
[Authorize]
public sealed class ColourController : ControllerBase
{
    private readonly CrudControllerHelper<Colour, Data.Colour, Data.Colour, Data.Post.Colour> _crud;

    public ColourController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Colour, Data.Colour, Data.Colour, Data.Post.Colour>(db, mapper);
    }

    [HttpGet("{identifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<Data.Colour>> Get(Guid identifier)
    {
        return await _crud.GetAsync(identifier);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Colour>>> Get()
    {
        return await _crud.GetAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Data.Colour>> Post(Data.Post.Colour model)
    {
        return await _crud.PostAsync(model);
    }

    [HttpPut]
    public async Task<ActionResult<Data.Colour>> Put(Data.Colour model)
    {
        return await _crud.PutAsync(model);
    }

    [HttpDelete("{identifier}")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        return await _crud.DeleteAsync(identifier);
    }
}
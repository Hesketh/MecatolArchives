using AutoMapper;
using Hesketh.MecatolArchives.API.Helpers;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("achievements")]
[Authorize]
public sealed class AchievementController : ControllerBase
{
    private readonly CrudControllerHelper<Achievement, Data.Achievement, Data.Achievement, Data.Post.Achievement> _crud;

    public AchievementController(MecatolArchivesDbContext db, IMapper mapper)
    {
        _crud = new CrudControllerHelper<Achievement, Data.Achievement, Data.Achievement, Data.Post.Achievement>(db, mapper);
    }

    [HttpGet("{identifier}")]
    [AllowAnonymous]
    public async Task<ActionResult<Data.Achievement>> Get(Guid identifier)
    {
        return await _crud.GetAsync(identifier);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.Achievement>>> Get()
    {
        return await _crud.GetAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Data.Achievement>> Post(Data.Post.Achievement model)
    {
        return await _crud.PostAsync(model);
    }

    [HttpPut]
    public async Task<ActionResult<Data.Achievement>> Put(Data.Achievement model)
    {
        return await _crud.PutAsync(model);
    }

    [HttpDelete("{identifier}")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        return await _crud.DeleteAsync(identifier);
    }
}
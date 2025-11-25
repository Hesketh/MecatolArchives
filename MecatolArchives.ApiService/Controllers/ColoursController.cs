using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MecatolArchives.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ColoursController(IColourManagementService colourManagementService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Colour>> Create(CreateColourRequest model)
    {
        return await colourManagementService.CreateColourAsync(model);
    }

    [HttpGet("{identifier}")]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<ActionResult<Colour>> Read(Guid identifier)
    {
        return await colourManagementService.ReadColourAsync(identifier);
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueriedCollection<Colour>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<ActionResult<QueriedCollection<Colour>>> Read([FromQuery] QueryParameters query)
    {
        return await colourManagementService.ReadColoursAsync(query);
    }

    [HttpPut("{identifier}")]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Colour>> Update(Guid identifier, UpdateColourRequest model)
    {
        return await colourManagementService.UpdateColourAsync(identifier, model);
    }

    [HttpDelete("{identifier}")]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        await colourManagementService.DeleteColourAsync(identifier);
        return Ok();
    }
}

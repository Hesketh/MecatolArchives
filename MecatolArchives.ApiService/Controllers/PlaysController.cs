using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MecatolArchives.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaysController(IPlayManagementService playManagementService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Play), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Create Play")]
    [EndpointDescription("Creates a new play.")]
    public async Task<ActionResult<Play>> Create(PlayCreateRequest model)
    {
        return await playManagementService.CreateAsync(model);
    }

    [HttpGet("{identifier}")]
    [ProducesResponseType(typeof(Play), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Play")]
    [EndpointDescription("Read the Play with the matching identifier.")]
    public async Task<ActionResult<Play>> Read(Guid identifier)
    {
        return await playManagementService.ReadAsync(identifier);
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueriedCollection<Play>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Plays")]
    [EndpointDescription("Read Plays with a Paged Query.")]
    public async Task<ActionResult<QueriedCollection<Play>>> Read([FromQuery] QueryParameters query)
    {
        return await playManagementService.ReadAsync(query);
    }

    [HttpPut("{identifier}")]
    [ProducesResponseType(typeof(Play), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Update Play")]
    [EndpointDescription("Update the properties of an existing Play with the matching identifier.")]
    public async Task<ActionResult<Play>> Update(Guid identifier, PlayUpdateRequest model)
    {
        return await playManagementService.UpdateAsync(identifier, model);
    }

    [HttpDelete("{identifier}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Delete Play")]
    [EndpointDescription("Delete the Play with the matching identifier.")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        await playManagementService.DeleteAsync(identifier);
        return Ok();
    }
}

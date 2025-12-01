using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MecatolArchives.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColoursController(IColourManagementService colourManagementService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Create Colour")]
    [EndpointDescription("Creates a new player game piece colour.")]
    public async Task<ActionResult<Colour>> Create(ColourCreateRequest model)
    {
        return await colourManagementService.CreateColourAsync(model);
    }

    [HttpGet("{identifier}")]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Colour")]
    [EndpointDescription("Read the Colour with the matching identifier.")]
    public async Task<ActionResult<Colour>> Read(Guid identifier)
    {
        return await colourManagementService.ReadColourAsync(identifier);
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueriedCollection<Colour>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Colours")]
    [EndpointDescription("Read the Colours with a Paged Query.")]
    public async Task<ActionResult<QueriedCollection<Colour>>> Read([FromQuery] QueryParameters query)
    {
        return await colourManagementService.ReadColoursAsync(query);
    }

    [HttpPut("{identifier}")]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Update Colour")]
    [EndpointDescription("Update the properties of an existing Colour with the matching identifier.")]
    public async Task<ActionResult<Colour>> Update(Guid identifier, ColourUpdateRequest model)
    {
        return await colourManagementService.UpdateColourAsync(identifier, model);
    }

    [HttpDelete("{identifier}")]
    [ProducesResponseType(typeof(Colour), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Delete Colour")]
    [EndpointDescription("Delete the Colour with the matching identifier.")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        await colourManagementService.DeleteColourAsync(identifier);
        return Ok();
    }
}

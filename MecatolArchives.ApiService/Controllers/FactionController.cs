using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MecatolArchives.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FactionsController(IFactionManagementService factionManagementService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Faction), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Create Faction")]
    [EndpointDescription("Creates a new faction.")]
    public async Task<ActionResult<Faction>> Create(FactionCreateRequest model)
    {
        return await factionManagementService.CreateAsync(model);
    }

    [HttpGet("{identifier}")]
    [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Faction")]
    [EndpointDescription("Read the Faction with the matching identifier.")]
    public async Task<ActionResult<Faction>> Read(Guid identifier)
    {
        return await factionManagementService.ReadAsync(identifier);
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueriedCollection<Faction>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Factions")]
    [EndpointDescription("Read the Factions with a Paged Query.")]
    public async Task<ActionResult<QueriedCollection<Faction>>> Read([FromQuery] QueryParameters query)
    {
        return await factionManagementService.ReadAsync(query);
    }

    [HttpPut("{identifier}")]
    [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Update Faction")]
    [EndpointDescription("Update the properties of an existing Faction with the matching identifier.")]
    public async Task<ActionResult<Faction>> Update(Guid identifier, FactionUpdateRequest model)
    {
        return await factionManagementService.UpdateAsync(identifier, model);
    }

    [HttpDelete("{identifier}")]
    [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Delete Faction")]
    [EndpointDescription("Delete the Faction with the matching identifier.")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        await factionManagementService.DeleteAsync(identifier);
        return Ok();
    }
}

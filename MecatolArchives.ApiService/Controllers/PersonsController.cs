using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MecatolArchives.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonsController(IPersonManagementService personManagementService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Create Person")]
    [EndpointDescription("Creates a new person who can be a player.")]
    public async Task<ActionResult<Person>> Create(PersonCreateRequest model)
    {
        return await personManagementService.CreateAsync(model);
    }

    [HttpGet("{identifier}")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Person")]
    [EndpointDescription("Read the Person with the matching identifier.")]
    public async Task<ActionResult<Person>> Read(Guid identifier)
    {
        return await personManagementService.ReadAsync(identifier);
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueriedCollection<Person>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Persons")]
    [EndpointDescription("Read the Persons with a Paged Query.")]
    public async Task<ActionResult<QueriedCollection<Person>>> Read([FromQuery] QueryParameters query)
    {
        return await personManagementService.ReadAsync(query);
    }

    [HttpPut("{identifier}")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Update Person")]
    [EndpointDescription("Update the properties of an existing Person with the matching identifier.")]
    public async Task<ActionResult<Person>> Update(Guid identifier, PersonUpdateRequest model)
    {
        return await personManagementService.UpdateAsync(identifier, model);
    }

    [HttpDelete("{identifier}")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Delete Person")]
    [EndpointDescription("Delete the Person with the matching identifier.")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        await personManagementService.DeleteAsync(identifier);
        return Ok();
    }
}

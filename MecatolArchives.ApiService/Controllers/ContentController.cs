using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MecatolArchives.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContentsController(IContentManagementService contentManagementService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Content), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Create Content")]
    [EndpointDescription("Creates a new content group.")]
    public async Task<ActionResult<Content>> Create(ContentCreateRequest model)
    {
        return await contentManagementService.CreateAsync(model);
    }

    [HttpGet("{identifier}")]
    [ProducesResponseType(typeof(Content), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Content")]
    [EndpointDescription("Read the Content with the matching identifier.")]
    public async Task<ActionResult<Content>> Read(Guid identifier)
    {
        return await contentManagementService.ReadAsync(identifier);
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueriedCollection<Content>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Contents")]
    [EndpointDescription("Read the Contents with a Paged Query.")]
    public async Task<ActionResult<QueriedCollection<Content>>> Read([FromQuery] QueryParameters query)
    {
        return await contentManagementService.ReadAsync(query);
    }

    [HttpPut("{identifier}")]
    [ProducesResponseType(typeof(Content), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Update Content")]
    [EndpointDescription("Update the properties of an existing Content with the matching identifier.")]
    public async Task<ActionResult<Content>> Update(Guid identifier, ContentUpdateRequest model)
    {
        return await contentManagementService.UpdateAsync(identifier, model);
    }

    [HttpDelete("{identifier}")]
    [ProducesResponseType(typeof(Content), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Delete Content")]
    [EndpointDescription("Delete the Content with the matching identifier.")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        await contentManagementService.DeleteAsync(identifier);
        return Ok();
    }
}

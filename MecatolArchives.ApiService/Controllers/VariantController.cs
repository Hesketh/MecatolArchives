using MecatolArchives.Domain.Dto;
using MecatolArchives.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MecatolArchives.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VariantsController(IVariantManagementService variantManagementService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Variant), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Create Variant")]
    [EndpointDescription("Creates a new game variant")]
    public async Task<ActionResult<Variant>> Create(VariantCreateRequest model)
    {
        return await variantManagementService.CreateAsync(model);
    }

    [HttpGet("{identifier}")]
    [ProducesResponseType(typeof(Variant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Variant")]
    [EndpointDescription("Read the Variant with the matching identifier.")]
    public async Task<ActionResult<Variant>> Read(Guid identifier)
    {
        return await variantManagementService.ReadAsync(identifier);
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueriedCollection<Variant>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Read Variants")]
    [EndpointDescription("Read the Variants with a Paged Query.")]
    public async Task<ActionResult<QueriedCollection<Variant>>> Read([FromQuery] QueryParameters query)
    {
        return await variantManagementService.ReadAsync(query);
    }

    [HttpPut("{identifier}")]
    [ProducesResponseType(typeof(Variant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EndpointSummary("Update Variant")]
    [EndpointDescription("Update the properties of an existing Variant with the matching identifier.")]
    public async Task<ActionResult<Variant>> Update(Guid identifier, VariantUpdateRequest model)
    {
        return await variantManagementService.UpdateAsync(identifier, model);
    }

    [HttpDelete("{identifier}")]
    [ProducesResponseType(typeof(Variant), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Delete Variant")]
    [EndpointDescription("Delete the Variant with the matching identifier.")]
    public async Task<IActionResult> Delete(Guid identifier)
    {
        await variantManagementService.DeleteAsync(identifier);
        return Ok();
    }
}

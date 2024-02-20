using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("admin")]
[Authorize]
public sealed class AdminController : ControllerBase
{
    [HttpGet]
    public ActionResult<bool> ConfirmAsync()
    {
        return Ok(true);
    }
}
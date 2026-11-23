using Microsoft.AspNetCore.Mvc;

using Saywell.Api.Dtos;
using Saywell.Api.Services;

namespace Saywell.Api.Controllers;

[ApiController]
[Route("api/proverbs")]
public class ProverbsController : ControllerBase
{
  private readonly ProverbService _proverbService;

  public ProverbsController(ProverbService proverbService)
  {
    _proverbService = proverbService;
  }

  [HttpGet("random")]
  [ProducesResponseType<ProverbResponse>(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<ProverbResponse> GetRandom([FromQuery] string? category)
  {
    var proverb = _proverbService.GetRandom(category);

    if (proverb is null)
    {
      return NotFound();
    }

    return Ok(proverb);
  }
}
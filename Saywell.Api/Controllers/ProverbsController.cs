using Microsoft.AspNetCore.Mvc;

namespace Saywell.Api.Controllers;

[ApiController]
[Route("api/proverbs")]
public class ProverbsController : ControllerBase
{
  [HttpGet("random")]
  public IActionResult GetRandom()
  {
    // Create anonymous object representing a proverb
    var proverb = new
    {
      Title = "Simplicity",
      Content = "Simplicity is the ultimate sophistication.",
      Author = "Unknown",
      Category = "Computers"
    };

    // Return 200 OK and the proverb as a JSON response
    return Ok(proverb);
  }
}
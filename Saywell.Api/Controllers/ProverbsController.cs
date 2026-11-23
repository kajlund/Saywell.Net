using Microsoft.AspNetCore.Mvc;

using Saywell.Api.Dtos;

namespace Saywell.Api.Controllers;

[ApiController]
[Route("api/proverbs")]
public class ProverbsController : ControllerBase
{
  [HttpGet("random")]
  public ActionResult<ProverbResponse> GetRandom([FromQuery] string? category)
  {
    // Create a list of sample ProverbResponse records to simulate a database of proverbs
    ProverbResponse[] proverbs = [
      new ("Simplicity", "Less is more", "Computers"),
      new ("Experience", "Practice makes perfect", "Learning"),
      new ("Persistence", "Every journey begins with a single step", "Life")
    ];

    var candidates = proverbs
      .Where(p => category == null ||
        p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
      .ToArray();

    if (candidates.Length == 0)
    {
      return NotFound();
    }

    var proverb = candidates[Random.Shared.Next(candidates.Length)];

    // Return 200 OK and the randomly selected proverb as a JSON response
    return Ok(proverb);
  }
}
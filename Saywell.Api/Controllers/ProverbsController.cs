using Microsoft.AspNetCore.Mvc;

namespace Saywell.Api.Controllers;

[ApiController]
[Route("api/proverbs")]
public class ProverbsController : ControllerBase
{
  [HttpGet("random")]
  public IActionResult GetRandom()
  {
    // Create a list of anonymous objects representing a proverbs
    var proverbs = new[]
    {
      new { Title = "Simplicity", Content = "Less is more", Category = "Computers" },
      new { Title = "Experience", Content = "Practice makes perfect", Category = "Learning" },
      new { Title = "Persistence", Content = "Every journey begins with a single step", Category = "Life" }
    };

    var proverb = proverbs[Random.Shared.Next(proverbs.Length)];

    // Return 200 OK and the randomly selected proverb as a JSON response
    return Ok(proverb);
  }
}
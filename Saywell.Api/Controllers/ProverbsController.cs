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

  [HttpGet]
  [ProducesResponseType<ProverbResponse[]>(StatusCodes.Status200OK)]
  public ActionResult<IReadOnlyList<ProverbResponse>> GetAll()
  {
    return Ok(_proverbService.GetAll());
  }

  [HttpGet("{id:guid}", Name = "GetProverbById")]
  [ProducesResponseType<ProverbResponse>(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<ProverbResponse> GetById([FromRoute] Guid id)
  {
    var proverb = _proverbService.GetById(id);

    if (proverb is null)
    {
      return NotFound();
    }

    return Ok(proverb);
  }

  [HttpPost]
  [ProducesResponseType<ProverbResponse>(StatusCodes.Status201Created)]
  [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
  public ActionResult<ProverbResponse> Create(
  [FromBody] CreateProverbRequest request)
  {
    var proverb = _proverbService.Create(request);

    return CreatedAtRoute(
      "GetProverbById",
      new { id = proverb.Id },
      proverb
    );
  }

  [HttpPut("{id:guid}")]
  [ProducesResponseType<ProverbResponse>(StatusCodes.Status200OK)]
  [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<ProverbResponse> Update(
  [FromRoute] Guid id,
  [FromBody] UpdateProverbRequest request)
  {
    var proverb = _proverbService.Update(id, request);

    if (proverb is null)
    {
      return NotFound();
    }

    return Ok(proverb);
  }

  [HttpDelete("{id:guid}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public IActionResult Delete([FromRoute] Guid id)
  {
    if (!_proverbService.Delete(id))
    {
      return NotFound();
    }

    return NoContent();
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
using Saywell.Api.Dtos;

namespace Saywell.Api.Services;

public class ProverbService
{
  private readonly ProverbResponse[] _proverbs =
  [
    new("Simplicity", "Less is more", "Computers"),
    new("Experience", "Practice makes perfect", "Learning"),
    new("Persistence", "Every journey begins with a single step", "Life")
  ];

  public ProverbResponse? GetRandom(string? category)
  {
    var candidates = _proverbs
      .Where(p => category == null ||
        p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
      .ToArray();

    if (candidates.Length == 0)
    {
      return null;
    }

    return candidates[Random.Shared.Next(candidates.Length)];
  }
}
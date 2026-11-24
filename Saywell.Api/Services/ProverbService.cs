using Saywell.Api.Dtos;

namespace Saywell.Api.Services;

public class ProverbService
{
  private static readonly ProverbResponse[] _proverbs =
  [
    new(Guid.CreateVersion7(), "Simplicity", "Less is more", "Unknown", "Computers"),
    new(Guid.CreateVersion7(), "Experience", "Practice makes perfect", "Unknown", "Learning"),
    new(Guid.CreateVersion7(), "Persistence", "Every journey begins with a single step", "Unknown", "Life")
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
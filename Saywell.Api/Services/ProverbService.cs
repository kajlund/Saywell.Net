using System.Collections.Concurrent;

using Saywell.Api.Dtos;

namespace Saywell.Api.Services;

public class ProverbService
{
  private static readonly ConcurrentDictionary<Guid, ProverbResponse> _proverbs = new();
  // Static constructors execute automatically once per type, before the first instance is created or any static members are referenced.
  static ProverbService()
  {
    ProverbResponse[] initialProverbs =
    [
      new(Guid.CreateVersion7(), "Simplicity",
      "Less is more", "Unknown", "Computers"),
    new(Guid.CreateVersion7(), "Experience",
      "Practice makes perfect", "Unknown", "Learning"),
    new(Guid.CreateVersion7(), "Persistence",
      "Every journey begins with a single step", "Unknown", "Life")
    ];

    foreach (var proverb in initialProverbs)
    {
      _proverbs.TryAdd(proverb.Id, proverb);
    }
  }

  public IReadOnlyList<ProverbResponse> GetAll()
  {
    return _proverbs.Values.ToArray();
  }

  public ProverbResponse? GetById(Guid id)
  {
    return _proverbs.TryGetValue(id, out var proverb)
      ? proverb
      : null;
  }
  public ProverbResponse Create(CreateProverbRequest request)
  {
    var proverb = new ProverbResponse(
      Guid.CreateVersion7(),
      request.Title.Trim(),
      request.Content.Trim(),
      request.Author.Trim(),
      request.Category.Trim()
    );

    if (!_proverbs.TryAdd(proverb.Id, proverb))
    {
      throw new InvalidOperationException("Duplicate proverb ID.");
    }

    return proverb;
  }

  public ProverbResponse? GetRandom(string? category)
  {
    var candidates = _proverbs.Values
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
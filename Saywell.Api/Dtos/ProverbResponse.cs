namespace Saywell.Api.Dtos;

public record ProverbResponse(
  Guid Id,
  string Title,
  string Content,
  string Author,
  string Category
);
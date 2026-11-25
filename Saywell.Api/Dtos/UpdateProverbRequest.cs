using System.ComponentModel.DataAnnotations;

namespace Saywell.Api.Dtos;

public record UpdateProverbRequest(
  [Required]
  [StringLength(200)]
  string Title,

  [Required]
  [StringLength(5000)]
  string Content,

  [Required]
  [StringLength(200)]
  string Author,

  [Required]
  [StringLength(100)]
  string Category
);
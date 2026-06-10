using System.ComponentModel.DataAnnotations;

namespace application.dtos.entities;

public sealed record CreateAncestryDto
{
    [Required]
    public string Name { get; init; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Lifespan { get; init; }

    [Required]
    public string Size { get; init; } = string.Empty;

    public ICollection<string> Elements { get; init; } = new List<string>();
}

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Entities;


/**
 * public AuthorDto(Author entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Createdat = entity.Createdat;
        BooksIds = entity.Books?.Select(b =>b.Id).ToList() ?? new List<string>();
    }
 */

public sealed record AncestryDto(Guid Id, string Name, int Lifespan, string Size, ICollection<string> Elements);

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

public sealed record EditAncestryDto
{
    [Required]
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    [Range(0, int.MaxValue)]
    public int Lifespan { get; init; }
    public string Size { get; init; } = string.Empty;
    public ICollection<string> Elements { get; init; } = new List<string>();
}

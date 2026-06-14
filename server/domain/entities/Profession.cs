using Domain.Enums;

namespace Domain.Entities;

public sealed record Profession
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty; 
    public string StarterAttribute { get; set; }
    public string StarterMastery { get; set; } = string.Empty;
}
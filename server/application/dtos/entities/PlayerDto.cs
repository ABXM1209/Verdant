namespace Application.DTOs.Entities;

public sealed record PlayerDto(Guid Id, Guid UserId, Guid CreatureId, Guid AncestryId);

public record CreatePlayerDto(
    Guid UserId,
    Guid AncestryId,
    string Name,
    int CreatureType,
    int Gender,
    int Str,
    int Agi,
    int Dur,
    int Spi
);

public sealed record EditPlayerDto
{
    public Guid Id { get; init; }
    public Guid AncestryId { get; init; } 
}
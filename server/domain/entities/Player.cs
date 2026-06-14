namespace Domain.Entities;
public sealed record Player
{
    //extends from creature, can have multiple professions, and one ancestry
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid CreatureId { get; set; }
    public Guid AncestryId { get; set; }
}
namespace Domain.Entities;
public sealed record Player
{
    //extends from creatre, has a profession and an ancestry
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CreatureId { get; set; }
    public Guid ProfessionId { get; set; }
    public Guid AncestryId { get; set; }
}
using domain.enums;

namespace domain.entities;  

public sealed record Creature
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public CreatureType CreatureType { get; set; } = CreatureType.Player;
    public string Name { get; set; } = string.Empty;
    public GenderType Gender { get; set; } = GenderType.Unknown;
    public int Str { get; set; }
    public int Agi { get; set; }
    public int Dur { get; set; }
    public int Spi { get; set; }
    public int HpMax { get; set; }
    public int SpMax { get; set; }
    public int HpCurrent { get; set; }
    public int SpCurrent { get; set; }
}
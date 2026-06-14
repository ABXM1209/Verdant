using Domain.Enums;

namespace Domain.Entities;

public sealed record Creature
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public CreatureTypeEnum CreatureType { get; set; } = CreatureTypeEnum.Minia;
    public string Name { get; set; } = string.Empty;
    public GenderEnum Gender { get; set; } = GenderEnum.Unknown;
    public int Str { get; set; }
    public int Agi { get; set; }
    public int Dur { get; set; }
    public int Spi { get; set; }
    public int HpMax { get; set; }
    public int SpMax { get; set; }
    public int HpCurrent { get; set; }
    public int SpCurrent { get; set; }


    public const int HPPerDur = 5;
    public const int SPPerSpi = 5;
    
    public static int CalculateHpMax(int dur) => dur * HPPerDur;
    public static int CalculateSpMax(int spi) => spi * SPPerSpi;
}
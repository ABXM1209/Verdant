namespace Application.DTOs.Entities;

public sealed record CreatureDto(Guid Id, int CreatureType, string Name, int Str, int Agi, int Dur, int Spi, int HpMax, int SpMax, int HpCurrent, int SpCurrent);

public sealed record CreateCreatureDto
{
	public int CreatureType { get; init; }
	public string Name { get; init; } = string.Empty;
	public int Str { get; init; }
	public int Agi { get; init; }
	public int Dur { get; init; }
	public int Spi { get; init; }
}

public sealed record EditCreatureDto
{
	public Guid Id { get; init; }
	public int CreatureType { get; init; }
	public string Name { get; init; } = string.Empty;
	public int Str { get; init; }
	public int Agi { get; init; }
	public int Dur { get; init; }
	public int Spi { get; init; }
	public int HpMax { get; init; }
	public int SpMax { get; init; }
	public int HpCurrent { get; init; }
	public int SpCurrent { get; init; }
}
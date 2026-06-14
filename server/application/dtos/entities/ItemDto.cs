using Domain.Enums;

namespace Application.DTOs.Entities;

public sealed record ItemDto(Guid Id, string Name, string Description, int Price, ItemWeightClassEnum WeightClassEnum, ItemTypeEnum TypeEnum);

public sealed record CreateItemDto
{
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public int Price { get; init; }
	public ItemWeightClassEnum WeightClassEnum { get; init; }
	public ItemTypeEnum TypeEnum { get; init; }
}

public sealed record EditItemDto
{
	public Guid Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public int Price { get; init; }
	public ItemWeightClassEnum WeightClassEnum { get; init; }
	public ItemTypeEnum TypeEnum { get; init; }
}
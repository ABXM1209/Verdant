using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class ItemService(IItemRepository itemRepository) : IItemService
{
    public async Task<IEnumerable<ItemDto>> GetAllAsync()
    {
        var items = await itemRepository.GetAllAsync();
        return items.Select(i => new ItemDto(i.Id, i.Name, i.Description, i.Price, i.WeightClassEnum, i.TypeEnum));
    }

    public async Task<ItemDto> GetByIdAsync(Guid id)
    {
        var i = await itemRepository.FindByIdAsync(id);
        return new ItemDto(i.Id, i.Name, i.Description, i.Price, i.WeightClassEnum, i.TypeEnum);
    }

    public async Task<ItemDto> CreateAsync(CreateItemDto dto)
    {
        var entity = new Item { Name = dto.Name, Description = dto.Description, Price = dto.Price, WeightClassEnum = dto.WeightClassEnum, TypeEnum = dto.TypeEnum };
        var created = await itemRepository.AddAsync(entity);
        return new ItemDto(created.Id, created.Name, created.Description, created.Price, created.WeightClassEnum, created.TypeEnum);
    }

    public async Task<ItemDto> UpdateAsync(EditItemDto dto)
    {
        var entity = await itemRepository.FindByIdAsync(dto.Id);
        entity = entity with { Name = dto.Name, Description = dto.Description, Price = dto.Price, WeightClassEnum = dto.WeightClassEnum, TypeEnum = dto.TypeEnum };
        await itemRepository.UpdateAsync(entity);
        return new ItemDto(entity.Id, entity.Name, entity.Description, entity.Price, entity.WeightClassEnum, entity.TypeEnum);
    }

    public async Task<bool> DeleteAsync(Guid id) => await itemRepository.DeleteAsync(id);
}

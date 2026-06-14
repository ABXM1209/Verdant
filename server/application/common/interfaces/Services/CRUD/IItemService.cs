using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IItemService
{
    Task<IEnumerable<ItemDto>> GetAllAsync();
    Task<ItemDto> GetByIdAsync(Guid id);
    Task<ItemDto> CreateAsync(CreateItemDto dto);
    Task<ItemDto> UpdateAsync(EditItemDto dto);
    Task<bool> DeleteAsync(Guid id);
}

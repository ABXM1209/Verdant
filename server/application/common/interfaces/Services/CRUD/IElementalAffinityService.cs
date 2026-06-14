using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IElementalAffinityService
{
    Task<IEnumerable<ElementalAffinityDto>> GetAllAsync();
    Task<ElementalAffinityDto> GetByIdAsync(Guid id);
    Task<ElementalAffinityDto> CreateAsync(CreateElementalAffinityDto dto);
    Task<ElementalAffinityDto> UpdateAsync(EditElementalAffinityDto dto);
    Task<bool> DeleteAsync(Guid id);
}

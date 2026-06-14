using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IAncestralTraitService
{
    Task<IEnumerable<AncestralTraitDto>> GetAllAsync();
    Task<AncestralTraitDto> GetByIdAsync(Guid id);
    Task<AncestralTraitDto> CreateAsync(CreateAncestralTraitDto dto);
    Task<AncestralTraitDto> UpdateAsync(EditAncestralTraitDto dto);
    Task<bool> DeleteAsync(Guid id);
}

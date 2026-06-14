using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IAncestryService
{
    Task<IEnumerable<AncestryDto>> GetAllAsync();
    Task<AncestryDto> GetByIdAsync(Guid id);
    Task<AncestryDto> CreateAsync(CreateAncestryDto dto);
    Task<AncestryDto> UpdateAsync(EditAncestryDto dto);
    Task<bool> DeleteAsync(Guid id);
}

using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface ITechniqueService
{
    Task<IEnumerable<TechniqueDto>> GetAllAsync();
    Task<TechniqueDto> GetByIdAsync(Guid id);
    Task<TechniqueDto> CreateAsync(CreateTechniqueDto dto);
    Task<TechniqueDto> UpdateAsync(EditTechniqueDto dto);
    Task<bool> DeleteAsync(Guid id);
}

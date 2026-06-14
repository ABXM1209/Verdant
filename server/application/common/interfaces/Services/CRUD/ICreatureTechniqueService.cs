using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface ICreatureTechniqueService
{
    Task<IEnumerable<CreatureTechniqueDto>> GetAllAsync();
    Task<CreatureTechniqueDto> GetByIdAsync(Guid id);
    Task<CreatureTechniqueDto> CreateAsync(CreateCreatureTechniqueDto dto);
    Task<CreatureTechniqueDto> UpdateAsync(EditCreatureTechniqueDto dto);
    Task<bool> DeleteAsync(Guid id);
}

using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface ICreatureProficiencyService
{
    Task<IEnumerable<CreatureProficiencyDto>> GetAllAsync();
    Task<CreatureProficiencyDto> GetByIdAsync(Guid id);
    Task<CreatureProficiencyDto> CreateAsync(CreateCreatureProficiencyDto dto);
    Task<CreatureProficiencyDto> UpdateAsync(EditCreatureProficiencyDto dto);
    Task<bool> DeleteAsync(Guid id);
}

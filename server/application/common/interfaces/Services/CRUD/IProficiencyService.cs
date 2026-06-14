using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IProficiencyService
{
    Task<IEnumerable<ProficiencyDto>> GetAllAsync();
    Task<ProficiencyDto> GetByIdAsync(Guid id);
    Task<ProficiencyDto> CreateAsync(CreateProficiencyDto dto);
    Task<ProficiencyDto> UpdateAsync(EditProficiencyDto dto);
    Task<bool> DeleteAsync(Guid id);
}

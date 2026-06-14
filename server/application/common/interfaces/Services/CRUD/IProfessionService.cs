using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IProfessionService
{
    Task<IEnumerable<ProfessionDto>> GetAllAsync();
    Task<ProfessionDto> GetByIdAsync(Guid id);
    Task<ProfessionDto> CreateAsync(CreateProfessionDto dto);
    Task<ProfessionDto> UpdateAsync(EditProfessionDto dto);
    Task<bool> DeleteAsync(Guid id);
}

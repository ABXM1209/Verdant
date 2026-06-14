using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface ICreatureService
{
    Task<IEnumerable<CreatureDto>> GetAllAsync();
    Task<CreatureDto> GetByIdAsync(Guid id);
    Task<CreatureDto> CreateAsync(CreateCreatureDto dto);
    Task<CreatureDto> UpdateAsync(EditCreatureDto dto);
    Task<bool> DeleteAsync(Guid id);
}

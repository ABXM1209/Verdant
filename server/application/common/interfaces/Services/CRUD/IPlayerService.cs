using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IPlayerService
{
    Task<IEnumerable<PlayerDto>> GetAllAsync();
    Task<PlayerDto> GetByIdAsync(Guid id);
    Task<PlayerDto> CreateAsync(CreatePlayerDto dto);
    Task<PlayerDto> UpdateAsync(EditPlayerDto dto);
    Task<bool> DeleteAsync(Guid id);
}

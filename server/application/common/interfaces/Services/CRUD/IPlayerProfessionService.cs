using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IPlayerProfessionService
{
    Task<IEnumerable<PlayerProfessionDto>> GetAllAsync();
    Task<PlayerProfessionDto> GetByIdAsync(Guid id);
    Task<PlayerProfessionDto> CreateAsync(CreatePlayerProfessionDto dto);
    Task<PlayerProfessionDto> UpdateAsync(EditPlayerProfessionDto dto);
    Task<bool> DeleteAsync(Guid id);
}

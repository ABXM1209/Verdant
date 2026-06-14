using Application.DTOs.Entities;

namespace Application.Common.Interfaces.Services.CRUD;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(Guid id);
    Task<UserDto> CreateAsync(CreateUserDto dto);
    Task<UserDto> UpdateAsync(EditUserDto dto);
    Task<bool> DeleteAsync(Guid id);
}

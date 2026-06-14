using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Utilities;

namespace Application.Services.CRUD;

public class UserService(IUserRepository userRepository, IHashingUtils hashingUtils) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var items = await userRepository.GetAllAsync();
        return items.Select(u => new UserDto(u.Id, u.FirstName, u.LastName, u.Email, (int)u.Role));
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var u = await userRepository.FindByIdAsync(id);
        return new UserDto(u.Id, u.FirstName, u.LastName, u.Email, (int)u.Role);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Password))
            throw new ArgumentException("Password is required.", nameof(dto.Password));

        hashingUtils.CreatePasswordHash(dto.Password, out var passwordHash);

        var entity = User.Create(dto.FirstName, dto.LastName, dto.Email, passwordHash, (Domain.Enums.RoleTypeEnum)dto.Role);
        var created = await userRepository.AddAsync(entity);
        return new UserDto(created.Id, created.FirstName, created.LastName, created.Email, (int)created.Role);
    }

    public async Task<UserDto> UpdateAsync(EditUserDto dto)
    {
        var entity = await userRepository.FindByIdAsync(dto.Id);
        entity = entity with { FirstName = dto.FirstName, LastName = dto.LastName, Email = dto.Email, Role = (Domain.Enums.RoleTypeEnum)dto.Role };
        await userRepository.UpdateAsync(entity);
        return new UserDto(entity.Id, entity.FirstName, entity.LastName, entity.Email, (int)entity.Role);
    }

    public async Task<bool> DeleteAsync(Guid id) => await userRepository.DeleteAsync(id);
}

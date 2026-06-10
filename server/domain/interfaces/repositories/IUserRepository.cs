using domain.entities;

namespace domain.interfaces.repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<bool> IsUserExistByEmailAsync(string email);
}
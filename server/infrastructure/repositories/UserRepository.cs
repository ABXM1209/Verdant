using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<User> _set;

    public UserRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<User>();
    }

    public async Task<User> AddAsync(User entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(User entity)
    {
        _set.Remove(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _set.FindAsync(id);
        if (entity == null) return false;
        _set.Remove(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<User> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(User entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _set.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<bool> IsUserExistByEmailAsync(string email)
    {
        return await _set.AnyAsync(x => x.Email == email);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(MyDbContext dbContext) : IUserRepository
{

    public async Task<User> AddAsync(User entity)
    {
        try
        {
            var created = await dbContext.Users.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return created.Entity;
        }
        catch(DbUpdateException e)
        {
            throw new RepositoryException(e.Message, e);
        }
    }
    
    public async Task<bool> DeleteAsync(User entity)
    {
        try
        {
            dbContext.Users.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException e)
        {
            throw new RepositoryException(e.Message, e);
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var existing = await dbContext.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (existing == null)
                return false;
    
            dbContext.Users.Remove(existing);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException e)
        {
            throw new RepositoryException(e.Message, e);
        }
    }

    public async Task<User> FindByIdAsync(Guid id)
    {
        var message = await dbContext.Users
            .FirstOrDefaultAsync(m => m.Id == id);

        return message ?? throw new EntityNotFoundException("User not found, make sure the id is correct");
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await dbContext.Users.ToListAsync();
    }

    public async Task<bool> UpdateAsync(User entity)
    {
        try
        {
            var existing = await dbContext.Users.FirstOrDefaultAsync(m => m.Id == entity.Id);
            if (existing == null)
                return false;
    
            dbContext.Entry(existing).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException e)
        {
            throw new RepositoryException($"Failed to update the user: {e.Message}", e);
        }
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user ?? throw new EntityNotFoundException($"User with email '{email}' not found");
    }

    public async Task<bool> IsUserExistByEmailAsync(string email)
    {
        try
        {
            return await dbContext.Users.ContainsAsync(await GetByEmailAsync(email));
        }
        catch (EntityNotFoundException)
        {
            return false;
        }
    }
}

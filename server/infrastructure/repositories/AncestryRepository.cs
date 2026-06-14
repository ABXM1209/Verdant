using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AncestryRepository(MyDbContext dbContext) : IAncestryRepository
{

    public async Task<Ancestry> AddAsync(Ancestry entity)
    {
        try
        {
            var created = await dbContext.Ancestries.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return created.Entity;
        }
        catch(DbUpdateException e)
        {
            throw new RepositoryException(e.Message, e);
        }
    }

    public async Task<bool> DeleteAsync(Ancestry entity)
    {
        try
        {
            dbContext.Ancestries.Remove(entity);
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
            var existing = await dbContext.Ancestries.FirstOrDefaultAsync(m => m.Id == id);
            if (existing == null)
                return false;
    
            dbContext.Ancestries.Remove(existing);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException e)
        {
            throw new RepositoryException(e.Message, e);
        }
    }

    public async Task<Ancestry> FindByIdAsync(Guid id)
    {
        var message = await dbContext.Ancestries
            .FirstOrDefaultAsync(m => m.Id == id);

        return message ?? throw new EntityNotFoundException("Ancestry not found, make sure the id is correct");
    }

    public async Task<IEnumerable<Ancestry>> GetAllAsync()
    {
        return await dbContext.Ancestries.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Ancestry entity)
    {
        try
        {
            var existing = await dbContext.Ancestries.FirstOrDefaultAsync(m => m.Id == entity.Id);
            if (existing == null)
                return false;
    
            dbContext.Entry(existing).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException e)
        {
            throw new RepositoryException($"Failed to update the ancestry: {e.Message}", e);
        }
    }
    
}

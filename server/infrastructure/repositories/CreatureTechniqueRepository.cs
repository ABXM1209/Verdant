using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CreatureTechniqueRepository : ICreatureTechniqueRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<CreatureTechnique> _set;

    public CreatureTechniqueRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<CreatureTechnique>();
    }

    public async Task<CreatureTechnique> AddAsync(CreatureTechnique entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(CreatureTechnique entity)
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

    public async Task<CreatureTechnique> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<CreatureTechnique>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(CreatureTechnique entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
}

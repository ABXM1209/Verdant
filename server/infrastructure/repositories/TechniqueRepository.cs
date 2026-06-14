using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TechniqueRepository : ITechniqueRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<Technique> _set;

    public TechniqueRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<Technique>();
    }

    public async Task<Technique> AddAsync(Technique entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Technique entity)
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

    public async Task<Technique> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<Technique>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Technique entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
}

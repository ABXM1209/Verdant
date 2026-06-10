using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.entities;
using domain.interfaces.repositories;
using Infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class ProficiencyRepository : IProficiencyRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<Proficiency> _set;

    public ProficiencyRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<Proficiency>();
    }

    public async Task<Proficiency> AddAsync(Proficiency entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Proficiency entity)
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

    public async Task<Proficiency> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<Proficiency>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Proficiency entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.entities;
using domain.interfaces.repositories;
using Infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class AncestryRepository : IAncestryRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<Ancestry> _set;

    public AncestryRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<Ancestry>();
    }

    public async Task<Ancestry> AddAsync(Ancestry entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Ancestry entity)
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

    public async Task<Ancestry> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<Ancestry>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Ancestry entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
    
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.entities;
using domain.interfaces.repositories;
using Infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class ElementalAffinityRepository : IElementalAffinityRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<ElementalAffinity> _set;

    public ElementalAffinityRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<ElementalAffinity>();
    }

    public async Task<ElementalAffinity> AddAsync(ElementalAffinity entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(ElementalAffinity entity)
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

    public async Task<ElementalAffinity> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<ElementalAffinity>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(ElementalAffinity entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
}

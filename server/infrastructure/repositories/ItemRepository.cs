using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.entities;
using domain.interfaces.repositories;
using Infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class ItemRepository : IItemRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<Item> _set;

    public ItemRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<Item>();
    }

    public async Task<Item> AddAsync(Item entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Item entity)
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

    public async Task<Item> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Item entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
}

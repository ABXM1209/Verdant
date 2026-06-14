using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProfessionRepository : IProfessionRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<Profession> _set;

    public ProfessionRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<Profession>();
    }

    public async Task<Profession> AddAsync(Profession entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Profession entity)
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

    public async Task<Profession> FindByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<Profession>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Profession entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
}

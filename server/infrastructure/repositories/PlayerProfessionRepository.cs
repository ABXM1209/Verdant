using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlayerProfessionRepository : IPlayerProfessionRepository
{
    private readonly MyDbContext _db;
    private readonly DbSet<PlayerProfession> _set;

    public PlayerProfessionRepository(MyDbContext db)
    {
        _db = db;
        _set = db.Set<PlayerProfession>();
    }

    public async Task<PlayerProfession> AddAsync(PlayerProfession entity)
    {
        await _set.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(PlayerProfession entity)
    {
        _set.Remove(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _set.FindAsync(id);
        if (existing == null) return false;
        _set.Remove(existing);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<PlayerProfession> FindByIdAsync(Guid id) => await _set.FindAsync(id);

    public async Task<IEnumerable<PlayerProfession>> GetAllAsync() => await _set.ToListAsync();

    public async Task<bool> UpdateAsync(PlayerProfession entity)
    {
        _set.Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.interfaces.repositories;
using domain.entities;
using Infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class CreatureRepository : ICreatureRepository
{
	private readonly MyDbContext _db;
	private readonly DbSet<Creature> _set;

	public CreatureRepository(MyDbContext db)
	{
		_db = db;
		_set = db.Set<Creature>();
	}

	public async Task<Creature> AddAsync(Creature entity)
	{
		await _set.AddAsync(entity);
		await _db.SaveChangesAsync();
		return entity;
	}

	public async Task<bool> DeleteAsync(Creature entity)
	{
		_set.Remove(entity);
		var changed = await _db.SaveChangesAsync();
		return changed > 0;
	}

	public async Task<bool> DeleteAsync(Guid id)
	{
		var entity = await _set.FindAsync(id);
		if (entity == null) return false;
		_set.Remove(entity);
		var changed = await _db.SaveChangesAsync();
		return changed > 0;
	}

	public async Task<Creature> FindByIdAsync(Guid id)
	{
		return await _set.FindAsync(id);
	}

	public async Task<IEnumerable<Creature>> GetAllAsync()
	{
		return await _set.ToListAsync();
	}

	public async Task<bool> UpdateAsync(Creature entity)
	{
		_set.Update(entity);
		var changed = await _db.SaveChangesAsync();
		return changed > 0;
	}
}
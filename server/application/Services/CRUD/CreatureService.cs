using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class CreatureService(ICreatureRepository creatureRepository) : ICreatureService
{
    public async Task<IEnumerable<CreatureDto>> GetAllAsync()
    {
        var items = await creatureRepository.GetAllAsync();
        return items.Select(c => new CreatureDto(c.Id, (int)c.CreatureType, c.Name, c.Str, c.Agi, c.Dur, c.Spi, c.HpMax, c.SpMax, c.HpCurrent, c.SpCurrent));
    }

    public async Task<CreatureDto> GetByIdAsync(Guid id)
    {
        var c = await creatureRepository.FindByIdAsync(id);
        return new CreatureDto(c.Id, (int)c.CreatureType, c.Name, c.Str, c.Agi, c.Dur, c.Spi, c.HpMax, c.SpMax, c.HpCurrent, c.SpCurrent);
    }

    public async Task<CreatureDto> CreateAsync(CreateCreatureDto dto)
    {
        var hpMax = Creature.CalculateHpMax(dto.Dur);
        var spMax = Creature.CalculateSpMax(dto.Spi);
        
        var entity = new Creature
        {
            CreatureType = (Domain.Enums.CreatureTypeEnum)dto.CreatureType,
            Name = dto.Name,
            Str = dto.Str,
            Agi = dto.Agi,
            Dur = dto.Dur,
            Spi = dto.Spi,
            HpMax = hpMax,
            SpMax = spMax,
            HpCurrent = hpMax,
            SpCurrent = spMax
        };
        var created = await creatureRepository.AddAsync(entity);
        return new CreatureDto(created.Id, (int)created.CreatureType, created.Name, created.Str, created.Agi, created.Dur, created.Spi, created.HpMax, created.SpMax, created.HpCurrent, created.SpCurrent);
    }

    public async Task<CreatureDto> UpdateAsync(EditCreatureDto dto)
    {
        var entity = await creatureRepository.FindByIdAsync(dto.Id);
        
        var oldHpMax = entity.HpMax;
        var oldSpMax = entity.SpMax;

        var newHpMax = Creature.CalculateHpMax(dto.Dur);
        var newSpMax = Creature.CalculateSpMax(dto.Spi);
        
        var newHpCurrent = oldHpMax > 0
            ? (int)Math.Round(dto.HpCurrent * (newHpMax / (double)oldHpMax))
            : newHpMax;
        
        var newSpCurrent = oldSpMax > 0
            ? (int)Math.Round(dto.SpCurrent * (newSpMax / (double)oldSpMax))
            : newSpMax;
        
        newHpCurrent = Math.Clamp(newHpCurrent, 0, newHpMax);
        newSpCurrent = Math.Clamp(newSpCurrent, 0, newSpMax);
        
        entity = entity with
        {
            CreatureType = (Domain.Enums.CreatureTypeEnum)dto.CreatureType,
            Name = dto.Name,
            Str = dto.Str,
            Agi = dto.Agi,
            Dur = dto.Dur,
            Spi = dto.Spi,
            HpMax = newHpMax,
            SpMax = newSpMax,
            HpCurrent = newHpCurrent,
            SpCurrent = newSpCurrent
        };
        await creatureRepository.UpdateAsync(entity);
        return new CreatureDto(entity.Id, (int)entity.CreatureType, entity.Name, entity.Str, entity.Agi, entity.Dur, entity.Spi, entity.HpMax, entity.SpMax, entity.HpCurrent, entity.SpCurrent);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await creatureRepository.DeleteAsync(id);
    }
}

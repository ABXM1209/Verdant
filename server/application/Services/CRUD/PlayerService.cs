using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class PlayerService(IPlayerRepository repository, ICreatureRepository creatureRepository) : IPlayerService
{
    public async Task<IEnumerable<PlayerDto>> GetAllAsync()
    {
        var items = await repository.GetAllAsync();
        return items.Select(p => new PlayerDto(p.Id, p.UserId, p.CreatureId, p.AncestryId));
    }

    public async Task<PlayerDto> GetByIdAsync(Guid id)
    {
        var p = await repository.FindByIdAsync(id);
        return new PlayerDto(p.Id, p.UserId, p.CreatureId, p.AncestryId);
    }

    public async Task<PlayerDto> CreateAsync(CreatePlayerDto dto)
    {
        var hpMax = Creature.CalculateHpMax(dto.Dur);
        var spMax = Creature.CalculateSpMax(dto.Spi);

        var creature = new Creature
        {
            CreatureType = (Domain.Enums.CreatureTypeEnum)dto.CreatureType,
            Name = dto.Name,
            Gender = (Domain.Enums.GenderEnum)dto.Gender,
            Str = dto.Str,
            Agi = dto.Agi,
            Dur = dto.Dur,
            Spi = dto.Spi,
            HpMax = hpMax,
            SpMax = spMax,
            HpCurrent = hpMax,
            SpCurrent = spMax
        };
        var createdCreature = await creatureRepository.AddAsync(creature);

        var player = new Player
        {
            UserId = dto.UserId,
            CreatureId = createdCreature.Id,
            AncestryId = dto.AncestryId
            
        };
        var createdPlayer = await repository.AddAsync(player);

        return new PlayerDto(createdPlayer.Id, createdPlayer.UserId, createdPlayer.CreatureId, createdPlayer.AncestryId);
    }

    public async Task<PlayerDto> UpdateAsync(EditPlayerDto dto)
    {
        var entity = await repository.FindByIdAsync(dto.Id);
        entity = entity with { AncestryId = dto.AncestryId };
        await repository.UpdateAsync(entity);
        return new PlayerDto(entity.Id, entity.UserId, entity.CreatureId, entity.AncestryId);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var player = await repository.FindByIdAsync(id);
        var deleted = await repository.DeleteAsync(id);
        if (deleted)
        {
            await creatureRepository.DeleteAsync(player.CreatureId);
        }
        return deleted;
    }
}

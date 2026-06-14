using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class ElementalAffinityService(IElementalAffinityRepository repository) : IElementalAffinityService
{
    public async Task<IEnumerable<ElementalAffinityDto>> GetAllAsync()
    {
        var items = await repository.GetAllAsync();
        return items.Select(e => new ElementalAffinityDto(e.Id, e.CreatureId, (int)e.AffinityRoll, e.Elements));
    }

    public async Task<ElementalAffinityDto> GetByIdAsync(Guid id)
    {
        var e = await repository.FindByIdAsync(id);
        return new ElementalAffinityDto(e.Id, e.CreatureId, (int)e.AffinityRoll, e.Elements);
    }

    public async Task<ElementalAffinityDto> CreateAsync(CreateElementalAffinityDto dto)
    {
        var entity = new ElementalAffinity { CreatureId = dto.CreatureId, AffinityRoll = (Domain.Enums.ElementalAffinityRollEnum)dto.AffinityRoll, Elements = dto.Elements };
        var created = await repository.AddAsync(entity);
        return new ElementalAffinityDto(created.Id, created.CreatureId, (int)created.AffinityRoll, created.Elements);
    }

    public async Task<ElementalAffinityDto> UpdateAsync(EditElementalAffinityDto dto)
    {
        var entity = await repository.FindByIdAsync(dto.Id);
        entity = entity with { CreatureId = dto.CreatureId, AffinityRoll = (Domain.Enums.ElementalAffinityRollEnum)dto.AffinityRoll, Elements = dto.Elements };
        await repository.UpdateAsync(entity);
        return new ElementalAffinityDto(entity.Id, entity.CreatureId, (int)entity.AffinityRoll, entity.Elements);
    }

    public async Task<bool> DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}

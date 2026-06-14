using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class CreatureTechniqueService(ICreatureTechniqueRepository repository) : ICreatureTechniqueService
{
    public async Task<IEnumerable<CreatureTechniqueDto>> GetAllAsync()
    {
        var items = await repository.GetAllAsync();
        return items.Select(c => new CreatureTechniqueDto(c.Id, c.CreatureId, c.TechniqueId, c.SkillLevel));
    }

    public async Task<CreatureTechniqueDto> GetByIdAsync(Guid id)
    {
        var c = await repository.FindByIdAsync(id);
        return new CreatureTechniqueDto(c.Id, c.CreatureId, c.TechniqueId, c.SkillLevel);
    }

    public async Task<CreatureTechniqueDto> CreateAsync(CreateCreatureTechniqueDto dto)
    {
        var entity = new CreatureTechnique { CreatureId = dto.CreatureId, TechniqueId = dto.TechniqueId, SkillLevel = dto.SkillLevel };
        var created = await repository.AddAsync(entity);
        return new CreatureTechniqueDto(created.Id, created.CreatureId, created.TechniqueId, created.SkillLevel);
    }

    public async Task<CreatureTechniqueDto> UpdateAsync(EditCreatureTechniqueDto dto)
    {
        var entity = await repository.FindByIdAsync(dto.Id);
        entity = entity with { CreatureId = dto.CreatureId, TechniqueId = dto.TechniqueId, SkillLevel = dto.SkillLevel };
        await repository.UpdateAsync(entity);
        return new CreatureTechniqueDto(entity.Id, entity.CreatureId, entity.TechniqueId, entity.SkillLevel);
    }

    public async Task<bool> DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}

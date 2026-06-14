using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class TechniqueService(ITechniqueRepository techniqueRepository) : ITechniqueService
{
    public async Task<IEnumerable<TechniqueDto>> GetAllAsync()
    {
        var items = await techniqueRepository.GetAllAsync();
        return items.Select(t => new TechniqueDto(t.Id, t.Name, t.Type, t.RequiredSkill, t.Description));
    }

    public async Task<TechniqueDto> GetByIdAsync(Guid id)
    {
        var t = await techniqueRepository.FindByIdAsync(id);
        return new TechniqueDto(t.Id, t.Name, t.Type, t.RequiredSkill, t.Description);
    }

    public async Task<TechniqueDto> CreateAsync(CreateTechniqueDto dto)
    {
        var entity = new Technique
        {
            Name = dto.Name,
            Type = dto.Type,
            RequiredSkill = dto.RequiredSkill,
            Description = dto.Description
        };
        var created = await techniqueRepository.AddAsync(entity);
        return new TechniqueDto(created.Id, created.Name, created.Type, created.RequiredSkill, created.Description);
    }

    public async Task<TechniqueDto> UpdateAsync(EditTechniqueDto dto)
    {
        var entity = await techniqueRepository.FindByIdAsync(dto.Id);
        entity = entity with { Name = dto.Name, Type = dto.Type, RequiredSkill = dto.RequiredSkill, Description = dto.Description };
        await techniqueRepository.UpdateAsync(entity);
        return new TechniqueDto(entity.Id, entity.Name, entity.Type, entity.RequiredSkill, entity.Description);
    }

    public async Task<bool> DeleteAsync(Guid id) => await techniqueRepository.DeleteAsync(id);
}

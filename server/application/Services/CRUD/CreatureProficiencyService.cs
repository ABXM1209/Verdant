using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class CreatureProficiencyService(ICreatureProficiencyRepository repository) : ICreatureProficiencyService
{
    public async Task<IEnumerable<CreatureProficiencyDto>> GetAllAsync()
    {
        var items = await repository.GetAllAsync();
        return items.Select(c => new CreatureProficiencyDto(c.Id, c.CreatureId, c.ProficiencyId, c.Level));
    }

    public async Task<CreatureProficiencyDto> GetByIdAsync(Guid id)
    {
        var c = await repository.FindByIdAsync(id);
        return new CreatureProficiencyDto(c.Id, c.CreatureId, c.ProficiencyId, c.Level);
    }

    public async Task<CreatureProficiencyDto> CreateAsync(CreateCreatureProficiencyDto dto)
    {
        var entity = new CreatureProficiency { CreatureId = dto.CreatureId, ProficiencyId = dto.ProficiencyId, Level = dto.Level };
        var created = await repository.AddAsync(entity);
        return new CreatureProficiencyDto(created.Id, created.CreatureId, created.ProficiencyId, created.Level);
    }

    public async Task<CreatureProficiencyDto> UpdateAsync(EditCreatureProficiencyDto dto)
    {
        var entity = await repository.FindByIdAsync(dto.Id);
        entity = entity with { CreatureId = dto.CreatureId, ProficiencyId = dto.ProficiencyId, Level = dto.Level };
        await repository.UpdateAsync(entity);
        return new CreatureProficiencyDto(entity.Id, entity.CreatureId, entity.ProficiencyId, entity.Level);
    }

    public async Task<bool> DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}

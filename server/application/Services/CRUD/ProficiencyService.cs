using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class ProficiencyService(IProficiencyRepository proficiencyRepository) : IProficiencyService
{
    public async Task<IEnumerable<ProficiencyDto>> GetAllAsync()
    {
        var items = await proficiencyRepository.GetAllAsync();
        return items.Select(p => new ProficiencyDto(p.Id, p.Name, (int)p.CategoryEnum, p.Description));
    }

    public async Task<ProficiencyDto> GetByIdAsync(Guid id)
    {
        var p = await proficiencyRepository.FindByIdAsync(id);
        return new ProficiencyDto(p.Id, p.Name, (int)p.CategoryEnum, p.Description);
    }

    public async Task<ProficiencyDto> CreateAsync(CreateProficiencyDto dto)
    {
        var entity = new Proficiency { Name = dto.Name, CategoryEnum = (Domain.Enums.ProficiencyCategoryEnum)dto.Category, Description = dto.Description };
        var created = await proficiencyRepository.AddAsync(entity);
        return new ProficiencyDto(created.Id, created.Name, (int)created.CategoryEnum, created.Description);
    }

    public async Task<ProficiencyDto> UpdateAsync(EditProficiencyDto dto)
    {
        var entity = await proficiencyRepository.FindByIdAsync(dto.Id);
        entity = entity with { Name = dto.Name, CategoryEnum = (Domain.Enums.ProficiencyCategoryEnum)dto.Category, Description = dto.Description };
        await proficiencyRepository.UpdateAsync(entity);
        return new ProficiencyDto(entity.Id, entity.Name, (int)entity.CategoryEnum, entity.Description);
    }

    public async Task<bool> DeleteAsync(Guid id) => await proficiencyRepository.DeleteAsync(id);
}

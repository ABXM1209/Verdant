using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class AncestralTraitService(IAncestralTraitRepository repository) : IAncestralTraitService
{
    public async Task<IEnumerable<AncestralTraitDto>> GetAllAsync()
    {
        var items = await repository.GetAllAsync();
        return items.Select(a => new AncestralTraitDto(a.Id, a.AncestryId, a.Name, a.Description));
    }

    public async Task<AncestralTraitDto> GetByIdAsync(Guid id)
    {
        var a = await repository.FindByIdAsync(id);
        return new AncestralTraitDto(a.Id, a.AncestryId, a.Name, a.Description);
    }

    public async Task<AncestralTraitDto> CreateAsync(CreateAncestralTraitDto dto)
    {
        var entity = new AncestralTrait { AncestryId = dto.AncestryId, Name = dto.Name, Description = dto.Description };
        var created = await repository.AddAsync(entity);
        return new AncestralTraitDto(created.Id, created.AncestryId, created.Name, created.Description);
    }

    public async Task<AncestralTraitDto> UpdateAsync(EditAncestralTraitDto dto)
    {
        var entity = await repository.FindByIdAsync(dto.Id);
        entity = entity with { AncestryId = dto.AncestryId, Name = dto.Name, Description = dto.Description };
        await repository.UpdateAsync(entity);
        return new AncestralTraitDto(entity.Id, entity.AncestryId, entity.Name, entity.Description);
    }

    public async Task<bool> DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}

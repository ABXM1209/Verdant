using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class ProfessionService(IProfessionRepository professionRepository) : IProfessionService
{
    public async Task<IEnumerable<ProfessionDto>> GetAllAsync()
    {
        var items = await professionRepository.GetAllAsync();
        return items.Select(p => new ProfessionDto(p.Id, p.Name, p.StarterAttribute, p.StarterMastery));
    }

    public async Task<ProfessionDto> GetByIdAsync(Guid id)
    {
        var p = await professionRepository.FindByIdAsync(id);
        return new ProfessionDto(p.Id, p.Name, p.StarterAttribute, p.StarterMastery);
    }

    public async Task<ProfessionDto> CreateAsync(CreateProfessionDto dto)
    {
        var entity = new Profession { Name = dto.Name, StarterAttribute = dto.StarterAttribute, StarterMastery = dto.StarterMastery };
        var created = await professionRepository.AddAsync(entity);
        return new ProfessionDto(created.Id, created.Name, created.StarterAttribute, created.StarterMastery);
    }

    public async Task<ProfessionDto> UpdateAsync(EditProfessionDto dto)
    {
        var entity = await professionRepository.FindByIdAsync(dto.Id);
        entity = entity with { Name = dto.Name, StarterAttribute = dto.StarterAttribute, StarterMastery = dto.StarterMastery };
        await professionRepository.UpdateAsync(entity);
        return new ProfessionDto(entity.Id, entity.Name, entity.StarterAttribute, entity.StarterMastery);
    }

    public async Task<bool> DeleteAsync(Guid id) => await professionRepository.DeleteAsync(id);
}

using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class AncestryService(IAncestryRepository ancestryRepository) : IAncestryService
{
    public async Task<IEnumerable<AncestryDto>> GetAllAsync()
    {
        var ancestries = await ancestryRepository.GetAllAsync();
        return ancestries.Select(ToDto);
    }

    public async Task<AncestryDto> GetByIdAsync(Guid id)
    {
        var ancestry = await ancestryRepository.FindByIdAsync(id);
        return ToDto(ancestry);
    }

    public async Task<AncestryDto> CreateAsync(CreateAncestryDto dto)
    {
        var ancestry = new Ancestry
        {
            Name = dto.Name,
            Lifespan = dto.Lifespan,
            Size = dto.Size,
            Elements = dto.Elements
        };
        var created = await ancestryRepository.AddAsync(ancestry);
        return ToDto(created);
    }

    public async Task<AncestryDto> UpdateAsync(EditAncestryDto dto)
    {
        var ancestry = await ancestryRepository.FindByIdAsync(dto.Id);
        ancestry.Name = dto.Name;
        ancestry.Lifespan = dto.Lifespan;
        ancestry.Size = dto.Size;
        ancestry.Elements = dto.Elements;
        await ancestryRepository.UpdateAsync(ancestry);
        return ToDto(ancestry);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await ancestryRepository.DeleteAsync(id);
    }

    private static AncestryDto ToDto(Ancestry a) =>
        new(a.Id, a.Name, a.Lifespan, a.Size, a.Elements);
}

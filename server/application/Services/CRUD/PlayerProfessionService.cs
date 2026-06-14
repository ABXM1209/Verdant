using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services.CRUD;

public class PlayerProfessionService(IPlayerProfessionRepository repository) : IPlayerProfessionService
{
    public async Task<IEnumerable<PlayerProfessionDto>> GetAllAsync()
    {
        var items = await repository.GetAllAsync();
        return items.Select(p => new PlayerProfessionDto(p.Id, p.PlayerId, p.ProfessionId, p.CurrentTier));
    }

    public async Task<PlayerProfessionDto> GetByIdAsync(Guid id)
    {
        var p = await repository.FindByIdAsync(id);
        return new PlayerProfessionDto(p.Id, p.PlayerId, p.ProfessionId, p.CurrentTier);
    }

    public async Task<PlayerProfessionDto> CreateAsync(CreatePlayerProfessionDto dto)
    {
        var entity = new PlayerProfession { PlayerId = dto.PlayerId, ProfessionId = dto.ProfessionId };
        var created = await repository.AddAsync(entity);
        return new PlayerProfessionDto(created.Id, created.PlayerId, created.ProfessionId, created.CurrentTier);
    }

    public async Task<PlayerProfessionDto> UpdateAsync(EditPlayerProfessionDto dto)
    {
        var entity = await repository.FindByIdAsync(dto.Id);
        entity = entity with { PlayerId = dto.PlayerId, ProfessionId = dto.ProfessionId, CurrentTier = dto.CurrentTier };
        await repository.UpdateAsync(entity);
        return new PlayerProfessionDto(entity.Id, entity.PlayerId, entity.ProfessionId, entity.CurrentTier);
    }

    public async Task<bool> DeleteAsync(Guid id) => await repository.DeleteAsync(id);
}

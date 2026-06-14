using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class AncestralTraitRepository : IAncestralTraitRepository
{
    public Task<AncestralTrait> AddAsync(AncestralTrait entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(AncestralTrait entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<AncestralTrait> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AncestralTrait>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(AncestralTrait entity)
    {
        throw new NotImplementedException();
    }
}
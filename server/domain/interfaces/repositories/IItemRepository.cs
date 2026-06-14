using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IItemRepository : IBaseRepository<Item>
{
    // Add item-specific queries here
}

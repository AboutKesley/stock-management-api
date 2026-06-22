using Stock.Domain.Models;

namespace Stock.Application.Interfaces;

public interface IItemRepository
{
    Task<Item> CreateAsync(Item item, CancellationToken cancellationToken);
    Task<Item?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken);
    Task<Item?> UpdateAsync(int id, Item item, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
using Stock.Application.Dtos;

namespace Stock.Application.Interfaces;

public interface IItemService
{
    Task<ItemResponse> CreateAsync(CreateItemRequest request, CancellationToken cancellationToken);
    Task<ItemResponse?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<ItemResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<ItemResponse?> UpdateAsync(int id, UpdateItemRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
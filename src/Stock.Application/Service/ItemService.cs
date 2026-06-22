using Stock.Application.Dtos;
using Stock.Application.Interfaces;
using Stock.Application.Mappings;

namespace Stock.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<ItemResponse> CreateAsync(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var item = request.ToDomain();

        var createdItem = await _itemRepository.CreateAsync(item, cancellationToken);

        return createdItem.ToResponse();
    }

    public async Task<ItemResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(id, cancellationToken);

        return item?.ToResponse();
    }

    public async Task<IReadOnlyList<ItemResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllAsync(cancellationToken);

        return items
            .Select(item => item.ToResponse())
            .ToList();
    }

    public async Task<ItemResponse?> UpdateAsync(int id, UpdateItemRequest request, CancellationToken cancellationToken)
    {
        var item = request.ToDomain();

        var updatedItem = await _itemRepository.UpdateAsync(id, item, cancellationToken);

        return updatedItem?.ToResponse();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return await _itemRepository.DeleteAsync(id, cancellationToken);
    }
}
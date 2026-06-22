using Microsoft.EntityFrameworkCore;
using Stock.Application.Interfaces;
using Stock.Domain.Models;
using Stock.Infrastructure.Context;

namespace Stock.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly StockDbContext _context;

    public ItemRepository(StockDbContext context)
    {
        _context = context;
    }

    public async Task<Item> CreateAsync(Item item, CancellationToken cancellationToken)
    {
        _context.Items.Add(item);

        await _context.SaveChangesAsync(cancellationToken);

        return item;
    }

    public async Task<Item?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Items
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Items
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Item?> UpdateAsync(int id, Item item, CancellationToken cancellationToken)
    {
        var existingItem = await _context.Items
            .FirstOrDefaultAsync(currentItem => currentItem.Id == id, cancellationToken);

        if (existingItem is null)
            return null;

        existingItem.Update(item.Name, item.Quantity, item.Type);

        await _context.SaveChangesAsync(cancellationToken);

        return existingItem;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var item = await _context.Items
            .FirstOrDefaultAsync(currentItem => currentItem.Id == id, cancellationToken);

        if (item is null)
            return false;

        _context.Items.Remove(item);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
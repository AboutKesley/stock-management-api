using Stock.Domain.Models;

namespace Stock.Domain.Interfaces
{
    public interface IItemService
    {
        Item CreateItem(Item item);
    }
}

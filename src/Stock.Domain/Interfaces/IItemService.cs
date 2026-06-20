using Stock.Domain.Models;

namespace Stock.Domain.Interfaces
{
    public interface IItemService
    {
        Item Create(Item item);
        Item? GetById(int id);
        List<Item> GetAll();
        bool Delete(int id);
        Item? Update(int id, Item item);
    }
}

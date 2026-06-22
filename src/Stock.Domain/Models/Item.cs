using Stock.Domain.Enums;

namespace Stock.Domain.Models;

public class Item
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public ItemType Type { get; private set; }

    public Item()
    {
    }

    public static Item Create(string name, int quantity, ItemType type)
    {
        var item = new Item();
        item.Update(name, quantity, type);
        return item;
    }

    public void Update(string name, int quantity, ItemType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

        if (!Enum.IsDefined(typeof(ItemType), type))
            throw new ArgumentException("Invalid item type.", nameof(type));

        Name = name;
        Quantity = quantity;
        Type = type;
    }
}
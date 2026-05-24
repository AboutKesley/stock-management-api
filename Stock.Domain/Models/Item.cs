using Stock.Domain.Enums;
using System.Runtime.ExceptionServices;

namespace Stock.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public  string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public ItemType Type { get; set; }
        public decimal Price { get; set; }

        public static Item Create(string name, int quantity, ItemType type, decimal price)
        {
            var item = new Item();
            item.Update(name, quantity, type, price);
            return item;
        }

        public void Update(string name, int quantity, ItemType type, decimal price)
        {
            if(String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name");

            if(quantity <= 0)
                throw new ArgumentException("Quantity cannot be negative");

            if(!Enum.IsDefined(typeof(ItemType), type))
                throw new ArgumentException("Invalid item type.");

            if(price < 0) 
                throw new ArgumentException("Price cannot be negative.");

            Name = name;
            Quantity = quantity;
            Type = type;
            Price = price;
        }
    }
}

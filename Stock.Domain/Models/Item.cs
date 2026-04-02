using Stock.Domain.Enums;

namespace Stock.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public ItemType Type { get; set; }
    }
}

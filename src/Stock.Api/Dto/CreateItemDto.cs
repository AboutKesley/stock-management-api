using Stock.Domain.Enums;
using Stock.Domain.Models;

namespace Stock.Application.WebApi.Dto
{
    public class CreateItemDto
    {
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public ItemType Type { get; set; }

        public Item ToDomain()
        {
            return Item.Create(Name, Quantity, Type);
        }
    };    
}

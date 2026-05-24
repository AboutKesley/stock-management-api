using Stock.Domain.Models;

namespace Stock.Application.WebApi.Dto.Responses
{
    public class UpdateItemDto
    {
            public string Name { get; set; } = string.Empty;

            public int Quantity { get; set; }

            public int ItemType { get; set; }
            public decimal Price { get; set; }

        public Item ToDomain()
            {
                return new Item
                {
                    Name = this.Name,
                    Quantity = this.Quantity,
                    Type = (Domain.Enums.ItemType)this.ItemType,
                    Price = this.Price
                };
            }
    }
}

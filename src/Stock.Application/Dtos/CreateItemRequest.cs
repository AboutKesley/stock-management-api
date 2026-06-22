using Stock.Domain.Enums;

namespace Stock.Application.Dtos;

public sealed class CreateItemRequest
{
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public ItemType Type { get; set; }
}
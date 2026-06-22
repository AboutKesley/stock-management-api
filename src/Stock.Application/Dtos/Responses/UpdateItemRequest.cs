using Stock.Domain.Enums;

namespace Stock.Application.Dtos;

public sealed class UpdateItemRequest
{
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public ItemType Type { get; set; }
}
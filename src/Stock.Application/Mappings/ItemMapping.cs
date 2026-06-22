using Stock.Application.Dtos;
using Stock.Domain.Models;

namespace Stock.Application.Mappings;

public static class ItemMapping
{
    public static Item ToDomain(this CreateItemRequest request)
    {
        return Item.Create(request.Name, request.Quantity, request.Type);
    }

    public static Item ToDomain(this UpdateItemRequest request)
    {
        return Item.Create(request.Name, request.Quantity, request.Type);
    }

    public static ItemResponse ToResponse(this Item item)
    {
        return new ItemResponse(
            item.Id,
            item.Name,
            item.Quantity,
            item.Type);
    }
}
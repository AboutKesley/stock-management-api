using Stock.Domain.Enums;
using Stock.Domain.Models;
using System.Text.Json.Serialization;

namespace Stock.Application.Dto;

public class ItemDto
{
    [JsonPropertyName("Name")]
    public required string Name { get; set; }

    [JsonPropertyName("Quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("Type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ItemType Type { get; set; }

    public Item ToDomain()
    {
        return Item.Create(Name, Quantity, Type);
    }
}
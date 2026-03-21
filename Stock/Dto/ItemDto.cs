using System.Text.Json.Serialization;

namespace Stock.Dto
{
    public class ItemDto
    {
        [JsonPropertyName("Name")]
        public required string Name { get; set; }

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
    }
}

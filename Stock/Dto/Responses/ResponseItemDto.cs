namespace Stock.Application.WebApi.Dto.Responses
{
    public class ResponseItemDto
    {
        public required int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int ItemType { get; set; }
        public decimal Price { get; set; }


    }
}

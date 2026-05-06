using Stock.Application.WebApi.Dto.Responses;
using Stock.Domain.Models;
using System.Runtime.CompilerServices;

namespace Stock.Application.WebApi.Mappings
{
    public static class ItemMappingExtensions
    {
        public static ResponseItemDto ToResponseDto(this Item item)
        {
            return new ResponseItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity,
                ItemType = (int)item.Type
            };

        }
    }
}

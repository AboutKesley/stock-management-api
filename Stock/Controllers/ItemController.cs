using Microsoft.AspNetCore.Mvc;
using Stock.Application.WebApi.Dto.Responses;
using Stock.Domain.Interfaces;
using Stock.Domain.Services;
using Stock.Dto;

namespace Stock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController
    {
        public IItemService _itemService { get; set; }

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public ResponseItemDto CreateItem(ItemDto item)
        {
            try
            {
                var result = _itemService.CreateItem(item.ToDomain());

                var newItem = new ResponseItemDto
                {
                    Id = result.Id
                };

                return newItem;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
                throw;
            }
        }
    }
}

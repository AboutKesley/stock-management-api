using Microsoft.AspNetCore.Mvc;
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
        public ItemDto CreateItem(ItemDto item, bool isStockableItem)
        {
            try
            {
                _itemService.CreateItem(item.ToDomain());
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
                throw;
            }
        }
    }
}

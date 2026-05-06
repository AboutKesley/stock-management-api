using Microsoft.AspNetCore.Mvc;
using Stock.Application.WebApi.Dto;
using Stock.Application.WebApi.Dto.Responses;
using Stock.Domain.Interfaces;
using Stock.Dto;

namespace Stock.Application.WebApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public IActionResult CreateItem(CreateItemDto item)
        {
            try
            {
                var result = _itemService.Create(item.ToDomain());
                var responseDto = new ResponseItemDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Quantity = result.Quantity,
                    ItemType = (int)result.Type
                };

                return Created($"/api/items/{result.Id}",responseDto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
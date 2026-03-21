using Microsoft.AspNetCore.Mvc;
using Stock.Dto;
using System.IO.Pipes;

namespace Stock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        [HttpGet]
        [Route("get/{id}")]
        public ItemDto GetItemById([FromRoute] string id)
        {
            return new ItemDto
            {
                Name = $"Example Item. Id: {id}",
                Quantity = 10
            };
        }

        [HttpGet]
        [Route("getV2")]
        public ItemDto GetItemByIdV2([FromQuery] string id)
        {
            return new ItemDto
            {
                Name = $"Example Item. Id: {id}",
                Quantity = 10
            };
        }

        [HttpGet]
        [Route("getV3")]
        public ItemDto GetItemByIdV3([FromHeader(Name = "idHeader")] string id)
        {
            return new ItemDto
            {
                Name = $"Example Item. Id: {id}",
                Quantity = 10
            };
        }

        [HttpPost]
        [Route("store")]
        public ItemDto StoreItem(ItemDto item)
        {
            return item;
        }
    }
}

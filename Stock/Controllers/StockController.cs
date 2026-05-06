using Microsoft.AspNetCore.Mvc;
using Stock.Dto;

namespace Stock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        [HttpPost]
        [Route("store")]
        public ItemDto StoreItem(ItemDto item)
        {
            return item;
        }
    }
}

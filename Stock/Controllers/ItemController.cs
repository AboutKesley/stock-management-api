using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.WebApi.Dto;
using Stock.Application.WebApi.Dto.Responses;
using Stock.Application.WebApi.Mappings;
using Stock.Domain.Interfaces;
using Stock.Dto;

namespace Stock.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                var responseDto = result.ToResponseDto();

                return Created($"/items/{responseDto.Id}", responseDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var item = _itemService.GetById(id);

            if (item == null)
                return NotFound("Item not found.");

           var result = item.ToResponseDto();
         
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _itemService.GetAll();

            var response = items.Select(item => item.ToResponseDto()).ToList();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var result = _itemService.Delete(id);

            if (result == false)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, UpdateItemDto item)
        {
            if(item == null)
                return BadRequest("Item data is required.");

            var result = _itemService.Update(id, item.ToDomain());

            if(result == null)
                return NotFound("Item not found.");

            var responseDto = result.ToResponseDto();

            return Ok(responseDto);
        }
    }
}

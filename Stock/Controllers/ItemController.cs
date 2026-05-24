using Microsoft.AspNetCore.Mvc;
using Stock.Application.WebApi.Dto;
using Stock.Application.WebApi.Dto.Responses;
using Stock.Application.WebApi.Mappings;
using Stock.Domain.Interfaces;

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
            var result = _itemService.Create(item.ToDomain());
            var responseDto = result.ToResponseDto();

            return CreatedAtAction(
                nameof(GetById),
                new { id = responseDto.Id },
                responseDto
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _itemService.GetById(id);

            if (item == null)
                return NotFound("Item not found.");

            return Ok(item.ToResponseDto());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _itemService.GetAll();

            return Ok(items.Select(item => item.ToResponseDto()).ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _itemService.Delete(id);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateItemDto item)
        {
            if (item == null)
                return BadRequest("Item data is required.");

            var result = _itemService.Update(id, item.ToDomain());

            if (result == null)
                return NotFound("Item not found.");

            return Ok(result.ToResponseDto());
        }
    }
}
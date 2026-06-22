using Microsoft.AspNetCore.Mvc;
using Stock.Application.Dtos;
using Stock.Application.Interfaces;

namespace Stock.Api.Controllers;

[ApiController]
[Route("api/items")]
public sealed class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemResponse>> Create(
        [FromBody] CreateItemRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _itemService.CreateAsync(request, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = response.Id },
            response);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ItemResponse>> GetById(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var response = await _itemService.GetByIdAsync(id, cancellationToken);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ItemResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ItemResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var response = await _itemService.GetAllAsync(cancellationToken);

        return Ok(response);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ItemResponse>> Update(
        [FromRoute] int id,
        [FromBody] UpdateItemRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _itemService.UpdateAsync(id, request, cancellationToken);

        if (response is null)
            return NotFound();

        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var deleted = await _itemService.DeleteAsync(id, cancellationToken);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoService _service;

    public ProductosController(ProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var productos = await _service.GetAll(page, pageSize);

        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _service.GetById(id);

        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductoCreateDto dto)
    {
        var producto = await _service.Create(
            dto.Nombre,
            dto.Descripcion,
            dto.Precio,
            dto.Stock);

        return CreatedAtAction(
            nameof(GetById),
            new { id = producto.Id },
            producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        ProductoCreateDto dto)
    {
        var updated = await _service.Update(
            id,
            dto.Nombre,
            dto.Descripcion,
            dto.Precio);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    [HttpPost("{id}/increment-stock")]
    public async Task<IActionResult> IncrementStock(
        int id,
        StockUpdateDto dto)
    {
        var result = await _service.IncrementStock(id, dto.Cantidad);

        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpPost("{id}/decrement-stock")]
    public async Task<IActionResult> DecrementStock(
        int id,
        StockUpdateDto dto)
    {
        try
        {
            var result = await _service.DecrementStock(id, dto.Cantidad);

            if (!result)
                return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
    }
}
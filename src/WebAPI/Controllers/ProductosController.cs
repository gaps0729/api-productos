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
    [ProducesResponseType(StatusCodes.Status200OK)] 
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var productos = await _service.GetAll(page, pageSize);

        return Ok(productos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _service.GetById(id);

        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        return Ok(new
        {
        message = "Producto actualizado correctamente"
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.Delete(id);

        if (!deleted)
            return NotFound();

        return Ok(new
        {
        message = "Producto eliminado correctamente"
        });
    }

    [HttpPost("{id}/increment-stock")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> IncrementStock(
        int id,
        StockUpdateDto dto)
    {
        var result = await _service.IncrementStock(id, dto.Cantidad);

        if (!result)
            return NotFound();

        return Ok(new
        {
        message = "Stock incrementado correctamente"
        });
    }

    [HttpPost("{id}/decrement-stock")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DecrementStock(
        int id,
        StockUpdateDto dto)
    {
        try
        {
            var result = await _service.DecrementStock(id, dto.Cantidad);

            if (!result)
                return NotFound();

            return Ok(new
            {
            message = "Stock descontado correctamente"
            });
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
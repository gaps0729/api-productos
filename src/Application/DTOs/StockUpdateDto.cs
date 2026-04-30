using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class StockUpdateDto
{
    [Range(1, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    public int Cantidad { get; set; }
}
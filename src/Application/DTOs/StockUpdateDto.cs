using System.ComponentModel.DataAnnotations;


namespace Application.DTOs;

public class StockUpdateDto
{
    [Range(1, int.MinValue)]
    public int Cantidad { get; set; }
}
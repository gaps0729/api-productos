using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class ProductoCreateDto
{
    [Required]
    [MinLength(3)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Descripcion { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class ProductoCreateDto
{
    [Required]
    [MinLength(3)]
    public string Nombre { get; set; } = "Mouse Logitech";

    [Required]
    public string Descripcion { get; set; } = "Mouse inalámbrico";

    [Range(0.01, double.MaxValue)]
    public decimal Precio { get; set; } = 70000;

    [Range(0, int.MaxValue)]
    public int Stock { get; set; } = 15;
}
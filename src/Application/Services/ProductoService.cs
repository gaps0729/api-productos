using Domain.Entities;
using Domain.Ports;

namespace Application.Services;

public class ProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Producto>> GetAll(int page, int pageSize)
    {
        return await _repository.GetAllAsync(page, pageSize);
    }

    public async Task<Producto?> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Producto> Create(
        string nombre,
        string descripcion,
        decimal precio,
        int stock)
    {
        var producto = new Producto
        {
            Nombre = nombre,
            Descripcion = descripcion,
            Precio = precio,
            Stock = stock
        };

        await _repository.AddAsync(producto);

        return producto;
    }

    public async Task<bool> Update(
        int id,
        string nombre,
        string descripcion,
        decimal precio)
    {
        var producto = await _repository.GetByIdAsync(id);

        if (producto == null)
            return false;

        producto.Nombre = nombre;
        producto.Descripcion = descripcion;
        producto.Precio = precio;

        await _repository.UpdateAsync(producto);

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var producto = await _repository.GetByIdAsync(id);

        if (producto == null)
            return false;

        await _repository.DeleteAsync(producto);

        return true;
    }

    public async Task<bool> IncrementStock(int id, int cantidad)
    {
        if (cantidad < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo");
        }

        var producto = await _repository.GetByIdAsync(id);

        if (producto == null)
            return false;

        producto.Stock += cantidad;

        await _repository.UpdateAsync(producto);

        return true;
    }

    public async Task<bool> DecrementStock(int id, int cantidad)
    {
        if (cantidad < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo");
        }
        var producto = await _repository.GetByIdAsync(id);

        if (producto == null)
            return false;

        if (producto.Stock - cantidad < 0)
            throw new Exception("Stock insuficiente");

        producto.Stock -= cantidad;

        await _repository.UpdateAsync(producto);

        return true;
    }
}
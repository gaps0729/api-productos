using Domain.Entities;

namespace Domain.Ports;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAllAsync(int page, int pageSize);

    Task<Producto?> GetByIdAsync(int id);

    Task AddAsync(Producto producto);

    Task UpdateAsync(Producto producto);

    Task DeleteAsync(Producto producto);
}
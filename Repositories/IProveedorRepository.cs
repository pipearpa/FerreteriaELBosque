using FerreteriaElBosque.Models;

namespace FerreteriaElBosque.Repositories
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetAllAsync();

        Task<Proveedor> GetByIdAsync(int id);

        Task AddAsync(Proveedor proveedor);

        Task UpdateAsync(Proveedor proveedor);

        Task DeleteAsync(int id);
    }
}

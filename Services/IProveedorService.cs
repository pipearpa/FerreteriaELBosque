using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;

namespace FerreteriaElBosque.Services
{
    public interface IProveedorService
    {
        Task<IEnumerable<ProveedorDTO>> GetAllProveedorAsync();
        Task<ProveedorDTO> GetProveedorByIdAsync(int id);

        Task AddProveedorAsync(ProveedorDTO proveedor);

        Task UpdateProveedorAsync(ProveedorDTO proveedor);

        Task DeleteProveedorAsync(int id);
    }
}

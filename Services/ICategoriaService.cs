using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;

namespace FerreteriaElBosque.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAllCategoriaAsync();
        Task<CategoriaDTO> GetCategoriaByIdAsync(int id);
        Task AddCategoriaAsync(CategoriaDTO categoria);
        Task UpdateCategoriaAsync(CategoriaDTO categoria);
        Task DeleteCategoriaAsync(int id);
    }
}

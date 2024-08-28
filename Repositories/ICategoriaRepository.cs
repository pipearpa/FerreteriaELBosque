using FerreteriaElBosque.Models;

namespace FerreteriaElBosque.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task AddAsync(Categoria producto);
        Task UpdateAsync(Categoria producto);
        Task DeleteAsync(int id);


    }
}

using FerreteriaElBosque.Context;
using FerreteriaElBosque.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaElBosque.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly FerreteriaDbContext _context;

        public CategoriaRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _context.Set<Categoria>().ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Set<Categoria>().FindAsync(id);
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Set<Categoria>().AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Set<Categoria>().Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await GetByIdAsync(id);
            if (categoria != null)
            {
                _context.Set<Categoria>().Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}

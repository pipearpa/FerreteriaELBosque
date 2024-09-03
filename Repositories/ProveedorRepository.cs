using FerreteriaElBosque.Context;
using FerreteriaElBosque.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaElBosque.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly FerreteriaDbContext _context;

        public ProveedorRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Proveedor proveedor)
        {
             await _context.Set<Proveedor>().AddAsync(proveedor);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var proveedor = await GetByIdAsync(id);
            if (proveedor != null)
            {
                _context.Set<Proveedor>().Remove(proveedor);
                await _context.SaveChangesAsync();
            }


        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Set<Proveedor>().ToListAsync();
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {

            return await _context.Set<Proveedor>().FindAsync();
        }

        public async Task UpdateAsync(Proveedor proveedor)
        {
             _context.Set<Proveedor>().Update(proveedor);
             await _context.SaveChangesAsync();
        }
    }
}

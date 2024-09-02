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

        public Task AddAsync(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Set<Proveedor>().ToListAsync();
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {

            return await _context.Set<Proveedor>().FindAsync();
        }

        public Task UpdateAsync(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }
    }
}

using FerreteriaElBosque.Context;
using FerreteriaElBosque.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaElBosque.Repositories
{
    // Implementa la interfaz IProductoRepository para manejar operaciones CRUD sobre productos.
    public class ProductoRepository : IProductoRepository
    {
        // Campo privado para almacenar el contexto de la base de datos.
        // El contexto es utilizado para interactuar con la base de datos.
        private readonly FerreteriaDbContext _context;

        // Constructor de la clase ProductoRepository.
        // Recibe una instancia de DbContext y la asigna al campo _context.
        // La inyección de dependencias asegura que se pase la instancia correcta del contexto.
        public ProductoRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        // Implementa el método para obtener todos los productos de manera asíncrona.
        // Utiliza el contexto para acceder al conjunto de productos y retorna una lista de productos.
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            // Obtiene todos los productos del conjunto de productos y los convierte a una lista.
            return await _context.Set<Producto>().ToListAsync();
        }

        // Implementa el método para obtener un producto específico por su ID de manera asíncrona.
        // Utiliza el contexto para buscar el producto con el ID proporcionado.
        public async Task<Producto> GetByIdAsync(int id)
        {
            // Busca el producto con el ID proporcionado en el conjunto de productos.
            return await _context.Set<Producto>().FindAsync(id);
        }

        // Implementa el método para agregar un nuevo producto de manera asíncrona.
        // Utiliza el contexto para agregar el producto al conjunto de productos y guarda los cambios en la base de datos.
        public async Task AddAsync(Producto producto)
        {
            // Agrega el nuevo producto al conjunto de productos.
            await _context.Set<Producto>().AddAsync(producto);
            // Guarda los cambios realizados en el contexto en la base de datos.
            await _context.SaveChangesAsync();
        }

        // Implementa el método para actualizar un producto existente de manera asíncrona.
        // Utiliza el contexto para actualizar el producto en el conjunto de productos y guarda los cambios.
        public async Task UpdateAsync(Producto producto)
        {
            // Marca el producto como modificado en el contexto.
            _context.Set<Producto>().Update(producto);
            // Guarda los cambios realizados en el contexto en la base de datos.
            await _context.SaveChangesAsync();
        }

        // Implementa el método para eliminar un producto por su ID de manera asíncrona.
        // Busca el producto por ID, lo elimina del conjunto de productos y guarda los cambios en la base de datos.
        public async Task DeleteAsync(int id)
        {
            // Obtiene el producto con el ID proporcionado.
            var producto = await GetByIdAsync(id);
            // Verifica si el producto existe.
            if (producto != null)
            {
                // Elimina el producto del conjunto de productos.
                _context.Set<Producto>().Remove(producto);
                // Guarda los cambios realizados en el contexto en la base de datos.
                await _context.SaveChangesAsync();
            }
        }
    }
}

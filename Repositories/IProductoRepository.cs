using FerreteriaElBosque.Models;

namespace FerreteriaElBosque.Repositories
{
    public interface IProductoRepository
    {
        // Método para obtener todos los productos de manera asíncrona.
        // Retorna una tarea que representa la operación asincrónica, que al completarse devuelve una colección de productos.
        Task<IEnumerable<Producto>> GetAllAsync();

        // Método para obtener un producto específico por su ID de manera asíncrona.
        // Recibe el ID del producto como parámetro y retorna una tarea que representa la operación asincrónica.
        // Al completarse, devuelve el producto correspondiente o null si no se encuentra.
        Task<Producto> GetByIdAsync(int id);

        // Método para agregar un nuevo producto de manera asíncrona.
        // Recibe un objeto Producto como parámetro y retorna una tarea que representa la operación asincrónica.
        // No retorna valor, ya que la operación es una acción de escritura.
        Task AddAsync(Producto producto);

        // Método para actualizar un producto existente de manera asíncrona.
        // Recibe un objeto Producto con los datos actualizados y retorna una tarea que representa la operación asincrónica.
        // No retorna valor, ya que la operación es una acción de escritura.
        Task UpdateAsync(Producto producto);

        // Método para eliminar un producto específico por su ID de manera asíncrona.
        // Recibe el ID del producto a eliminar como parámetro y retorna una tarea que representa la operación asincrónica.
        // No retorna valor, ya que la operación es una acción de escritura.
        Task DeleteAsync(int id);
    }
}

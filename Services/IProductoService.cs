using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;

namespace FerreteriaElBosque.Services
{
    public interface IProductoService
    {
        // Método asíncrono para obtener todos los productos.
        // Retorna una colección de productos.
        Task<IEnumerable<ProductoDTO>> GetAllProductosAsync();

        // Método asíncrono para obtener un producto específico por su ID.
        // Retorna el producto con el ID proporcionado.
        Task<ProductoDTO> GetProductoByIdAsync(int id);

        // Método asíncrono para agregar un nuevo producto.
        // Recibe un objeto Producto y lo agrega a la base de datos.
        Task AddProductoAsync(ProductoDTO producto);

        // Método asíncrono para actualizar un producto existente.
        // Recibe un objeto Producto con los cambios y actualiza el producto en la base de datos.
        Task UpdateProductoAsync(ProductoDTO producto);

        // Método asíncrono para eliminar un producto por su ID.
        // Recibe el ID del producto a eliminar y lo elimina de la base de datos.
        Task DeleteProductoAsync(int id);
    }
}

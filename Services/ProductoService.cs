using AutoMapper;
using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;
using FerreteriaElBosque.Repositories;

namespace FerreteriaElBosque.Services
{
    public class ProductoService : IProductoService
    {
        // Campo privado para almacenar la instancia del repositorio de productos.
        // El repositorio es utilizado para realizar operaciones CRUD sobre los productos.
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;


        // Constructor de la clase ProductoService.
        // Recibe una instancia de IProductoRepository y la asigna al campo _productoRepository.
        // La inyección de dependencias asegura que se pase la instancia correcta del repositorio.
        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            // Asigna el parámetro 'productoRepository' al campo privado '_productoRepository'.
            _productoRepository = productoRepository;
            // Asigna el parámetro 'mapper' al campo privado '_mapper'.
            _mapper = mapper;

        }

        // Implementa el método para obtener todos los productos de manera asíncrona.
        // Utiliza el repositorio para obtener la lista de productos y retorna el resultado.
        public async Task<IEnumerable<ProductoDTO>> GetAllProductosAsync()
        {

            // Llama al método GetAllAsync del repositorio para obtener todos los productos.
            var productos = await _productoRepository.GetAllAsync();
            // Mapea de Producto a ProductoDTO usando AutoMapper
            return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
        }

        // Implementa el método para obtener un producto específico por su ID de manera asíncrona.
        // Utiliza el repositorio para buscar el producto con el ID proporcionado y retorna el resultado.
        public async Task<ProductoDTO> GetProductoByIdAsync(int id)
        {
            // Llama al método GetByIdAsync del repositorio para obtener el producto con el ID proporcionado.
            var producto = await _productoRepository.GetByIdAsync(id);
            // Mapea de Producto a ProductoDTO usando AutoMapper
            return _mapper.Map<ProductoDTO>(producto);

        }

        // Implementa el método para agregar un nuevo producto de manera asíncrona.
        // Utiliza el repositorio para agregar el producto y realizar la operación.
        public async Task AddProductoAsync(ProductoDTO productoDto)
        {
            // Mapea de ProductoDTO a Producto usando AutoMapper
            var producto = _mapper.Map<Producto>(productoDto);
            // Llama al método AddAsync del repositorio para agregar el nuevo producto.
            await _productoRepository.AddAsync(producto);
        }

        // Implementa el método para actualizar un producto existente de manera asíncrona.
        // Utiliza el repositorio para actualizar el producto y realizar la operación.
        public async Task UpdateProductoAsync(ProductoDTO productoDto)
        {
            // Mapea de ProductoDTO a Producto usando AutoMapper
            var producto = _mapper.Map<Producto>(productoDto);
            // Llama al método UpdateAsync del repositorio para actualizar el producto.
            await _productoRepository.UpdateAsync(producto);
        }

        // Implementa el método para eliminar un producto por su ID de manera asíncrona.
        // Utiliza el repositorio para eliminar el producto y realizar la operación.
        public async Task DeleteProductoAsync(int id)
        {
            // Llama al método DeleteAsync del repositorio para eliminar el producto con el ID proporcionado.
            await _productoRepository.DeleteAsync(id);
        }
    }
}

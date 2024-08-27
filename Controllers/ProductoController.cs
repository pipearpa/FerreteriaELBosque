using AutoMapper;
using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;
using FerreteriaElBosque.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaElBosque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // Campo privado para almacenar la instancia del servicio de productos.
        // Esta instancia se utiliza para realizar operaciones CRUD en los productos.
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        // Constructor del controlador ProductosController.
        // Recibe una instancia del servicio de productos y la asigna al campo privado.
        // La inyección de dependencias asegura que se pase la instancia correcta del servicio.
        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        // Acción GET para obtener todos los productos.
        // Este método maneja las solicitudes GET a la ruta base del controlador (api/productos).
        // Utiliza el servicio para obtener la lista de productos y retorna una respuesta con la lista.
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            // Llama al método GetAllProductosAsync del servicio para obtener todos los productos.
            var productos = await _productoService.GetAllProductosAsync();

            // Retorna una respuesta HTTP 200 OK con la lista de productos en el cuerpo de la respuesta.
            return Ok(productos);
        }

        // Acción GET para obtener un producto específico por su ID.
        // Este método maneja las solicitudes GET a la ruta api/productos/{id}.
        // Utiliza el servicio para obtener el producto con el ID dado.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            // Llama al método GetProductoByIdAsync del servicio para obtener el producto con el ID proporcionado.
            var producto = await _productoService.GetProductoByIdAsync(id);

            // Verifica si el producto es nulo (es decir, no se encontró un producto con el ID dado).
            if (producto == null)
                // Retorna una respuesta HTTP 404 Not Found si el producto no existe.
                return NotFound();
            // Mapea el producto a ProductoDTO usando AutoMapper
            var productoDto = _mapper.Map<ProductoDTO>(producto);

            // Retorna una respuesta HTTP 200 OK con el producto en el cuerpo de la respuesta.
            return Ok(productoDto);
        }

        // Acción POST para crear un nuevo producto.
        // Este método maneja las solicitudes POST a la ruta base del controlador (api/productos).
        // Recibe un objeto Producto en el cuerpo de la solicitud, lo agrega usando el servicio y retorna una respuesta.
        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] ProductoDTO productoDto)
        {

            // Mapea el ProductoDTO a Producto usando AutoMapper
            var producto = _mapper.Map<Producto>(productoDto);
            // Llama al método AddProductoAsync del servicio para agregar el nuevo producto a la base de datos.
            await _productoService.AddProductoAsync(productoDto);



            // Retorna una respuesta HTTP 201 Created con la URL del nuevo recurso creado en el encabezado Location.
            // Utiliza nameof(GetProducto) para generar la URL de manera segura.
            // El nuevo producto se incluye en el cuerpo de la respuesta.
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, productoDto);
        }

        // Acción PUT para actualizar un producto existente.
        // Este método maneja las solicitudes PUT a la ruta api/productos/{id}.
        // Verifica que el ID en la URL coincida con el ID del producto en el cuerpo de la solicitud.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] ProductoDTO productoDto)
        {
            // Mapea el ProductoDTO a Producto usando AutoMapper
            var producto = _mapper.Map<Producto>(productoDto);
            // Verifica si el ID en la URL coincide con el ID del producto en el cuerpo de la solicitud.
            if (id != producto.Id)
                // Retorna una respuesta HTTP 400 Bad Request si los IDs no coinciden.
                return BadRequest();

            // Llama al método UpdateProductoAsync del servicio para actualizar el producto en la base de datos.
            await _productoService.UpdateProductoAsync(productoDto);

            // Retorna una respuesta HTTP 204 No Content ya que la actualización se realizó con éxito y no hay contenido que retornar.
            return NoContent();
        }

        // Acción DELETE para eliminar un producto por su ID.
        // Este método maneja las solicitudes DELETE a la ruta api/productos/{id}.
        // Llama al método DeleteProductoAsync del servicio para eliminar el producto con el ID dado.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            // Llama al método DeleteProductoAsync del servicio para eliminar el producto con el ID proporcionado.
            await _productoService.DeleteProductoAsync(id);

            // Retorna una respuesta HTTP 204 No Content ya que la eliminación se realizó con éxito y no hay contenido que retornar.
            return NoContent();
        }
    }
}

namespace FerreteriaElBosque.Models
{
    public class Producto
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public int CantidadDisponible { get; set; }
        // Clave foránea para Categoria
        public int CategoriaId { get; set; }
        // Propiedad de navegación para Categoria
        public virtual Categoria Categorias { get; set; }  // Propiedad de navegación
        public ICollection<ProductoProveedor> ProductoProveedores { get; set; }
    }
}

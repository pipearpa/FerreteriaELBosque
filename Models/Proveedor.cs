namespace FerreteriaElBosque.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<ProductoProveedor> ProductoProveedores { get; set; }  // Relación muchos a muchos
    }
}

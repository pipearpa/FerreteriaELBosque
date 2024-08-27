namespace FerreteriaElBosque.Models
{
    public class ProductoProveedor
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}

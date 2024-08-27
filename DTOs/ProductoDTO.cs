namespace FerreteriaElBosque.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public int CantidadDisponible { get; set; }
        public int CategoriaId { get; set; }
    }
}

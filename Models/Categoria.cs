namespace FerreteriaElBosque.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Colección de Productos en la Categoria
        public virtual ICollection<Producto> Productos { get; set; }
    }
}

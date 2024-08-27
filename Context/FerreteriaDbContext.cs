using FerreteriaElBosque.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaElBosque.Context
{
    public class FerreteriaDbContext : DbContext
    {
        public FerreteriaDbContext(DbContextOptions<FerreteriaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ProductoProveedor> ProductoProveedores { get; set; } // DbSet para la tabla intermedia

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación muchos a muchos entre Producto y Proveedor
            modelBuilder.Entity<ProductoProveedor>()
                .HasKey(pp => new { pp.ProductoId, pp.ProveedorId });

            modelBuilder.Entity<ProductoProveedor>()
                .HasOne(pp => pp.Producto)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(pp => pp.ProductoId);

            modelBuilder.Entity<ProductoProveedor>()
                .HasOne(pp => pp.Proveedor)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(pp => pp.ProveedorId);

            // Relación uno a muchos entre Producto y Categoria
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categorias)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            // Relación uno a muchos entre Proveedor y ProductoProveedor
            modelBuilder.Entity<Proveedor>()
                .HasMany(pr => pr.ProductoProveedores)
                .WithOne(pp => pp.Proveedor)
                .HasForeignKey(pp => pp.ProveedorId);
        }
    }
}

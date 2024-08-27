using AutoMapper;
using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;

namespace FerreteriaElBosque
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>();
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<Proveedor, ProveedorDTO>();
            CreateMap<ProductoProveedor, ProductoProveedorDTO>();
        }
    }
}

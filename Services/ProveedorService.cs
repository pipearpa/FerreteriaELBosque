using AutoMapper;
using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;
using FerreteriaElBosque.Repositories;

namespace FerreteriaElBosque.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;

        public ProveedorService (IProveedorRepository proveedorRepository, IMapper mapper)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
        }

        public async Task AddProveedorAsync(ProveedorDTO proveedorDto)
        {
            var proveedores = _mapper.Map<Proveedor>(proveedorDto);
            await _proveedorRepository.AddAsync(proveedores);
        }

        public async Task DeleteProveedorAsync(int id)
        {
            await _proveedorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProveedorDTO>> GetAllProveedorAsync()
        {
            var proveedores = await _proveedorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProveedorDTO>> (proveedores);
        }

        public async Task<ProveedorDTO> GetProveedorByIdAsync(int id)
        {
            var proveedores = await _proveedorRepository.GetByIdAsync(id);
            return _mapper.Map<ProveedorDTO> (proveedores);

        }

        public async Task UpdateProveedorAsync(ProveedorDTO proveedorDto)
        {
            var proveedores = _mapper.Map<Proveedor>(proveedorDto);
            await _proveedorRepository.UpdateAsync(proveedores);
        }
    }
}

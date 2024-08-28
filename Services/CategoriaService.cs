using AutoMapper;
using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;
using FerreteriaElBosque.Repositories;

namespace FerreteriaElBosque.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllCategoriaAsync()
        {
             
             var categorias = await _categoriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);


        }

        public async Task<CategoriaDTO> GetCategoriaByIdAsync(int id)
        {
            var categorias = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categorias);
        }

        public async Task AddCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categorias = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.AddAsync(categorias);
        }

        public async Task UpdateCategoriaAsync(CategoriaDTO categoriaDto)
        {
            var categorias = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.UpdateAsync(categorias);
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }
    }
}

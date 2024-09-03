using AutoMapper;
using FerreteriaElBosque.DTOs;
using FerreteriaElBosque.Models;
using FerreteriaElBosque.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaElBosque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;
        private readonly IMapper _mapper;

        public ProveedorController(IProveedorService proveedorService, IMapper mapper)
        {
            _mapper = mapper;
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedor()
        {
            var proveedores = await _proveedorService.GetAllProveedorAsync();
            return Ok(proveedores);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProveedor(int id)
        {
            var proveedores = await _proveedorService.GetProveedorByIdAsync(id);

            if (proveedores == null)
                return NotFound();

            var proveedorDto = _mapper.Map<ProveedorDTO>(proveedores);
            return Ok(proveedorDto);

        }
        [HttpPost]
        public async Task<IActionResult> CreateProveedor([FromBody] ProveedorDTO proveedorDto)
        {
            var proveedor = _mapper.Map<Proveedor>(proveedorDto);
            await _proveedorService.AddProveedorAsync(proveedorDto);

            return CreatedAtAction(nameof(GetProveedor), new { id = proveedor.Id }, proveedorDto);


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProveedor(int id, [FromBody] ProveedorDTO proveedorDto)
        {
            var proveedores = _mapper.Map<Proveedor>(proveedorDto);
            if (id != proveedores.Id)
                return BadRequest();

            await _proveedorService.UpdateProveedorAsync(proveedorDto);
            return NoContent();
        }
        
         


        


         



    }
}

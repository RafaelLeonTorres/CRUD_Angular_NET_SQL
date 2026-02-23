using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaterialAPI.Data;
using MaterialAPI.Models;
using AutoMapper;
using MaterialAPI.Services;
using AutoMapper.QueryableExtensions;
using MaterialAPI.DTOs;

namespace MaterialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMaterialService _materialService;

        public MaterialsController(AppDbContext context, IMapper mapper, IMaterialService materialService)
        {
            _context = context;
            _mapper = mapper;
            _materialService = materialService;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialReadDTO>>> GetMaterial()
        {
            var materials = await _context.Material.
                                    OrderBy(m => m.Name).
                                    ProjectTo<MaterialReadDTO>(_mapper.ConfigurationProvider).
                                    ToListAsync();

            if (materials == null)
            {
                return NotFound();
            }

            return Ok(materials);
        }


        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialReadDTO>> GetMaterial(int id)
        {
            var material = await _context.Material.
                                    ProjectTo<MaterialReadDTO>(_mapper.ConfigurationProvider).
                                    FirstOrDefaultAsync(m => m.Id == id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialUpdateDTO material)
        {
            var materialSearch = await _context.Material.FirstOrDefaultAsync(x => x.Id == id);
            if (materialSearch == null || material == null)
            {
                return BadRequest();
            }

            var updated = await _materialService.UpdateAsync(id, material);

            return NoContent();
        }

        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(MaterialCreateDTO material)
        {
            if (material == null)
            {
                return BadRequest();
            }

            var materialToCreate = _mapper.Map<Material>(material);
            var materialCreated = _context.Material.Add(materialToCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = materialToCreate.Id }, material);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            await _materialService.DeleteAsync(id);

            return NoContent();
        }      
    }
}

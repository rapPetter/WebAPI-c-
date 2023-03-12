using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchool_Api.Context;
using LabSchool_Api.Models;
using AutoMapper;
using LabSchool_Api.Dto;

namespace LabSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedagogosController : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public PedagogosController(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Atendimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedagogo>>> GetPedagogos()
        {
          if (_context.Pedagogos == null)
          {
              return NotFound();
          }
           
            var Pedagogo = await _context.Pedagogos.ToListAsync();
            var PedagogosDto = _mapper.Map<IEnumerable<PedagogoDto>>(Pedagogo);

            return Ok(PedagogosDto);
        }

        // GET: api/Atendimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedagogo>> GetPedagogo(int id)
        {
          if (_context.Pedagogos == null)
          {
              return NotFound();
          }
            var pedagogo = await _context.Pedagogos.FindAsync(id);

            if (pedagogo == null)
            {
                return NotFound();
            }

            return pedagogo;
        }

        // PUT: api/Atendimentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedagogo(int id, Pedagogo pedagogo)
        {
            if (id != pedagogo.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(pedagogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedagogoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Atendimentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedagogo>> PostPedagogo(Pedagogo pedagogo)
        {
          if (_context.Pedagogos == null)
          {
              return Problem("Entity set 'LabSchoolContext.Pedagogos'  is null.");
          }
            _context.Pedagogos.Add(pedagogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedagogo", new { id = pedagogo.Codigo }, pedagogo);
        }

        // DELETE: api/Atendimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedagogo(int id)
        {
            if (_context.Pedagogos == null)
            {
                return NotFound();
            }
            var pedagogo = await _context.Pedagogos.FindAsync(id);
            if (pedagogo == null)
            {
                return NotFound();
            }

            _context.Pedagogos.Remove(pedagogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedagogoExists(int id)
        {
            return (_context.Pedagogos?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}

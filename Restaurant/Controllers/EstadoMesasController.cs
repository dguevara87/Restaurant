using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoMesasController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public EstadoMesasController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/EstadoMesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoMesa>>> GetEstadoMesa()
        {
            return await _context.EstadoMesa.ToListAsync();
        }

        // GET: api/EstadoMesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoMesa>> GetEstadoMesa(Guid id)
        {
            var estadoMesa = await _context.EstadoMesa.FindAsync(id);

            if (estadoMesa == null)
            {
                return NotFound();
            }

            return estadoMesa;
        }

        // PUT: api/EstadoMesas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoMesa(Guid id, EstadoMesa estadoMesa)
        {
            if (id != estadoMesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoMesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoMesaExists(id))
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

        // POST: api/EstadoMesas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EstadoMesa>> PostEstadoMesa(EstadoMesa estadoMesa)
        {
            _context.EstadoMesa.Add(estadoMesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoMesa", new { id = estadoMesa.Id }, estadoMesa);
        }

        // DELETE: api/EstadoMesas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoMesa>> DeleteEstadoMesa(Guid id)
        {
            var estadoMesa = await _context.EstadoMesa.FindAsync(id);
            if (estadoMesa == null)
            {
                return NotFound();
            }

            _context.EstadoMesa.Remove(estadoMesa);
            await _context.SaveChangesAsync();

            return estadoMesa;
        }

        private bool EstadoMesaExists(Guid id)
        {
            return _context.EstadoMesa.Any(e => e.Id == id);
        }
    }
}

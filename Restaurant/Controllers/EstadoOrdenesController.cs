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
    public class EstadoOrdenesController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public EstadoOrdenesController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/EstadoOrdenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoOrden>>> GetEstadoOrden()
        {
            return await _context.EstadoOrden.ToListAsync();
        }

        // GET: api/EstadoOrdenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoOrden>> GetEstadoOrden(Guid id)
        {
            var estadoOrden = await _context.EstadoOrden.FindAsync(id);

            if (estadoOrden == null)
            {
                return NotFound();
            }

            return estadoOrden;
        }

        // PUT: api/EstadoOrdenes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoOrden(Guid id, EstadoOrden estadoOrden)
        {
            if (id != estadoOrden.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoOrdenExists(id))
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

        // POST: api/EstadoOrdenes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EstadoOrden>> PostEstadoOrden(EstadoOrden estadoOrden)
        {
            _context.EstadoOrden.Add(estadoOrden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoOrden", new { id = estadoOrden.Id }, estadoOrden);
        }

        // DELETE: api/EstadoOrdenes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoOrden>> DeleteEstadoOrden(Guid id)
        {
            var estadoOrden = await _context.EstadoOrden.FindAsync(id);
            if (estadoOrden == null)
            {
                return NotFound();
            }

            _context.EstadoOrden.Remove(estadoOrden);
            await _context.SaveChangesAsync();

            return estadoOrden;
        }

        private bool EstadoOrdenExists(Guid id)
        {
            return _context.EstadoOrden.Any(e => e.Id == id);
        }
    }
}

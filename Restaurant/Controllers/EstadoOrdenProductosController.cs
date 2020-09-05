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
    public class EstadoOrdenProductosController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public EstadoOrdenProductosController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/EstadoOrdenProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoOrdenProducto>>> GetEstadoOrdenProducto()
        {
            return await _context.EstadoOrdenProducto.ToListAsync();
        }

        // GET: api/EstadoOrdenProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoOrdenProducto>> GetEstadoOrdenProducto(Guid id)
        {
            var estadoOrdenProducto = await _context.EstadoOrdenProducto.FindAsync(id);

            if (estadoOrdenProducto == null)
            {
                return NotFound();
            }

            return estadoOrdenProducto;
        }

        // PUT: api/EstadoOrdenProductos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoOrdenProducto(Guid id, EstadoOrdenProducto estadoOrdenProducto)
        {
            if (id != estadoOrdenProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoOrdenProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoOrdenProductoExists(id))
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

        // POST: api/EstadoOrdenProductos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EstadoOrdenProducto>> PostEstadoOrdenProducto(EstadoOrdenProducto estadoOrdenProducto)
        {
            _context.EstadoOrdenProducto.Add(estadoOrdenProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoOrdenProducto", new { id = estadoOrdenProducto.Id }, estadoOrdenProducto);
        }

        // DELETE: api/EstadoOrdenProductos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoOrdenProducto>> DeleteEstadoOrdenProducto(Guid id)
        {
            var estadoOrdenProducto = await _context.EstadoOrdenProducto.FindAsync(id);
            if (estadoOrdenProducto == null)
            {
                return NotFound();
            }

            _context.EstadoOrdenProducto.Remove(estadoOrdenProducto);
            await _context.SaveChangesAsync();

            return estadoOrdenProducto;
        }

        private bool EstadoOrdenProductoExists(Guid id)
        {
            return _context.EstadoOrdenProducto.Any(e => e.Id == id);
        }
    }
}

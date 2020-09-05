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
    public class EstadoProductosController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public EstadoProductosController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/EstadoProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoProducto>>> GetEstadoProducto()
        {
            return await _context.EstadoProducto.ToListAsync();
        }

        // GET: api/EstadoProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoProducto>> GetEstadoProducto(Guid id)
        {
            var estadoProducto = await _context.EstadoProducto.FindAsync(id);

            if (estadoProducto == null)
            {
                return NotFound();
            }

            return estadoProducto;
        }

        // PUT: api/EstadoProductos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoProducto(Guid id, EstadoProducto estadoProducto)
        {
            if (id != estadoProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoProductoExists(id))
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

        // POST: api/EstadoProductos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EstadoProducto>> PostEstadoProducto(EstadoProducto estadoProducto)
        {
            _context.EstadoProducto.Add(estadoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoProducto", new { id = estadoProducto.Id }, estadoProducto);
        }

        // DELETE: api/EstadoProductos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoProducto>> DeleteEstadoProducto(Guid id)
        {
            var estadoProducto = await _context.EstadoProducto.FindAsync(id);
            if (estadoProducto == null)
            {
                return NotFound();
            }

            _context.EstadoProducto.Remove(estadoProducto);
            await _context.SaveChangesAsync();

            return estadoProducto;
        }

        private bool EstadoProductoExists(Guid id)
        {
            return _context.EstadoProducto.Any(e => e.Id == id);
        }
    }
}

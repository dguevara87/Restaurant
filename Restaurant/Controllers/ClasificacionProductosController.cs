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
    public class ClasificacionProductosController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public ClasificacionProductosController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/ClasificacionProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasificacionProducto>>> GetClasificacionProducto()
        {
            return await _context.ClasificacionProducto.ToListAsync();
        }

        // GET: api/ClasificacionProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClasificacionProducto>> GetClasificacionProducto(Guid id)
        {
            var clasificacionProducto = await _context.ClasificacionProducto.FindAsync(id);

            if (clasificacionProducto == null)
            {
                return NotFound();
            }

            return clasificacionProducto;
        }

        // PUT: api/ClasificacionProductos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasificacionProducto(Guid id, ClasificacionProducto clasificacionProducto)
        {
            if (id != clasificacionProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(clasificacionProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasificacionProductoExists(id))
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

        // POST: api/ClasificacionProductos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClasificacionProducto>> PostClasificacionProducto(ClasificacionProducto clasificacionProducto)
        {
            _context.ClasificacionProducto.Add(clasificacionProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasificacionProducto", new { id = clasificacionProducto.Id }, clasificacionProducto);
        }

        // DELETE: api/ClasificacionProductos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClasificacionProducto>> DeleteClasificacionProducto(Guid id)
        {
            var clasificacionProducto = await _context.ClasificacionProducto.FindAsync(id);
            if (clasificacionProducto == null)
            {
                return NotFound();
            }

            _context.ClasificacionProducto.Remove(clasificacionProducto);
            await _context.SaveChangesAsync();

            return clasificacionProducto;
        }

        private bool ClasificacionProductoExists(Guid id)
        {
            return _context.ClasificacionProducto.Any(e => e.Id == id);
        }
    }
}

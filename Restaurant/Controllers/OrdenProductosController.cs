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
    public class OrdenProductosController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public OrdenProductosController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/OrdenProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenProducto>>> GetOrdenProducto()
        {
            return await _context.OrdenProducto.ToListAsync();
        }

        // GET: api/OrdenProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenProducto>> GetOrdenProducto(Guid id)
        {
            var ordenProducto = await _context.OrdenProducto.FindAsync(id);

            if (ordenProducto == null)
            {
                return NotFound();
            }

            return ordenProducto;
        }

        // PUT: api/OrdenProductos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenProducto(Guid id, OrdenProducto ordenProducto)
        {
            if (id != ordenProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenProductoExists(id))
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

        // POST: api/OrdenProductos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrdenProducto>> PostOrdenProducto(OrdenProducto ordenProducto)
        {
            _context.OrdenProducto.Add(ordenProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenProducto", new { id = ordenProducto.Id }, ordenProducto);
        }

        // DELETE: api/OrdenProductos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenProducto>> DeleteOrdenProducto(Guid id)
        {
            var ordenProducto = await _context.OrdenProducto.FindAsync(id);
            if (ordenProducto == null)
            {
                return NotFound();
            }

            _context.OrdenProducto.Remove(ordenProducto);
            await _context.SaveChangesAsync();

            return ordenProducto;
        }

        private bool OrdenProductoExists(Guid id)
        {
            return _context.OrdenProducto.Any(e => e.Id == id);
        }
    }
}

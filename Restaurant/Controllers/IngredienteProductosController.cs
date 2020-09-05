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
    public class IngredienteProductosController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public IngredienteProductosController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/IngredienteProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredienteProducto>>> GetIngredienteProducto()
        {
            return await _context.IngredienteProducto.ToListAsync();
        }

        // GET: api/IngredienteProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredienteProducto>> GetIngredienteProducto(Guid id)
        {
            var ingredienteProducto = await _context.IngredienteProducto.FindAsync(id);

            if (ingredienteProducto == null)
            {
                return NotFound();
            }

            return ingredienteProducto;
        }

        // PUT: api/IngredienteProductos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredienteProducto(Guid id, IngredienteProducto ingredienteProducto)
        {
            if (id != ingredienteProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredienteProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredienteProductoExists(id))
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

        // POST: api/IngredienteProductos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IngredienteProducto>> PostIngredienteProducto(IngredienteProducto ingredienteProducto)
        {
            _context.IngredienteProducto.Add(ingredienteProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredienteProducto", new { id = ingredienteProducto.Id }, ingredienteProducto);
        }

        // DELETE: api/IngredienteProductos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IngredienteProducto>> DeleteIngredienteProducto(Guid id)
        {
            var ingredienteProducto = await _context.IngredienteProducto.FindAsync(id);
            if (ingredienteProducto == null)
            {
                return NotFound();
            }

            _context.IngredienteProducto.Remove(ingredienteProducto);
            await _context.SaveChangesAsync();

            return ingredienteProducto;
        }

        private bool IngredienteProductoExists(Guid id)
        {
            return _context.IngredienteProducto.Any(e => e.Id == id);
        }
    }
}

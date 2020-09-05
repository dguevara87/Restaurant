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
    public class ClasificacionIngredientesController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public ClasificacionIngredientesController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/ClasificacionIngredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasificacionIngrediente>>> GetClasificacionIngrediente()
        {
            return await _context.ClasificacionIngrediente.ToListAsync();
        }

        // GET: api/ClasificacionIngredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClasificacionIngrediente>> GetClasificacionIngrediente(Guid id)
        {
            var clasificacionIngrediente = await _context.ClasificacionIngrediente.FindAsync(id);

            if (clasificacionIngrediente == null)
            {
                return NotFound();
            }

            return clasificacionIngrediente;
        }

        // PUT: api/ClasificacionIngredientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasificacionIngrediente(Guid id, ClasificacionIngrediente clasificacionIngrediente)
        {
            if (id != clasificacionIngrediente.Id)
            {
                return BadRequest();
            }

            _context.Entry(clasificacionIngrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasificacionIngredienteExists(id))
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

        // POST: api/ClasificacionIngredientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClasificacionIngrediente>> PostClasificacionIngrediente(ClasificacionIngrediente clasificacionIngrediente)
        {
            _context.ClasificacionIngrediente.Add(clasificacionIngrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasificacionIngrediente", new { id = clasificacionIngrediente.Id }, clasificacionIngrediente);
        }

        // DELETE: api/ClasificacionIngredientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClasificacionIngrediente>> DeleteClasificacionIngrediente(Guid id)
        {
            var clasificacionIngrediente = await _context.ClasificacionIngrediente.FindAsync(id);
            if (clasificacionIngrediente == null)
            {
                return NotFound();
            }

            _context.ClasificacionIngrediente.Remove(clasificacionIngrediente);
            await _context.SaveChangesAsync();

            return clasificacionIngrediente;
        }

        private bool ClasificacionIngredienteExists(Guid id)
        {
            return _context.ClasificacionIngrediente.Any(e => e.Id == id);
        }
    }
}

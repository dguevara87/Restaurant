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
    public class IngredientesController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public IngredientesController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/Ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngrediente()
        {
            return await _context.Ingrediente.ToListAsync();
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(Guid id)
        {
            var ingrediente = await _context.Ingrediente.FindAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return ingrediente;
        }

        // PUT: api/Ingredientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngrediente(Guid id, Ingrediente ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredienteExists(id))
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

        // POST: api/Ingredientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ingrediente>> PostIngrediente(Ingrediente ingrediente)
        {
            _context.Ingrediente.Add(ingrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngrediente", new { id = ingrediente.Id }, ingrediente);
        }

        // DELETE: api/Ingredientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ingrediente>> DeleteIngrediente(Guid id)
        {
            var ingrediente = await _context.Ingrediente.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.Ingrediente.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return ingrediente;
        }

        private bool IngredienteExists(Guid id)
        {
            return _context.Ingrediente.Any(e => e.Id == id);
        }
    }
}

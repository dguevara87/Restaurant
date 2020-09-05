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
    public class UnidadesMedidasController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public UnidadesMedidasController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadesMedidas>>> GetUnidadesMedidas()
        {
            return await _context.UnidadesMedidas.ToListAsync();
        }

        // GET: api/UnidadesMedidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadesMedidas>> GetUnidadesMedidas(Guid id)
        {
            var unidadesMedidas = await _context.UnidadesMedidas.FindAsync(id);

            if (unidadesMedidas == null)
            {
                return NotFound();
            }

            return unidadesMedidas;
        }

        // PUT: api/UnidadesMedidas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadesMedidas(Guid id, UnidadesMedidas unidadesMedidas)
        {
            if (id != unidadesMedidas.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidadesMedidas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadesMedidasExists(id))
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

        // POST: api/UnidadesMedidas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UnidadesMedidas>> PostUnidadesMedidas(UnidadesMedidas unidadesMedidas)
        {
            _context.UnidadesMedidas.Add(unidadesMedidas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadesMedidas", new { id = unidadesMedidas.Id }, unidadesMedidas);
        }

        // DELETE: api/UnidadesMedidas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidadesMedidas>> DeleteUnidadesMedidas(Guid id)
        {
            var unidadesMedidas = await _context.UnidadesMedidas.FindAsync(id);
            if (unidadesMedidas == null)
            {
                return NotFound();
            }

            _context.UnidadesMedidas.Remove(unidadesMedidas);
            await _context.SaveChangesAsync();

            return unidadesMedidas;
        }

        private bool UnidadesMedidasExists(Guid id)
        {
            return _context.UnidadesMedidas.Any(e => e.Id == id);
        }
    }
}

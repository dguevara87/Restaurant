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
    public class CentrosElaboracionesController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public CentrosElaboracionesController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/CentrosElaboraciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CentrosElaboracion>>> GetCentrosElaboracion()
        {
            return await _context.CentrosElaboracion.ToListAsync();
        }

        // GET: api/CentrosElaboraciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CentrosElaboracion>> GetCentrosElaboracion(Guid id)
        {
            var centrosElaboracion = await _context.CentrosElaboracion.FindAsync(id);

            if (centrosElaboracion == null)
            {
                return NotFound();
            }

            return centrosElaboracion;
        }

        // PUT: api/CentrosElaboraciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentrosElaboracion(Guid id, CentrosElaboracion centrosElaboracion)
        {
            if (id != centrosElaboracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(centrosElaboracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentrosElaboracionExists(id))
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

        // POST: api/CentrosElaboraciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CentrosElaboracion>> PostCentrosElaboracion(CentrosElaboracion centrosElaboracion)
        {
            _context.CentrosElaboracion.Add(centrosElaboracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCentrosElaboracion", new { id = centrosElaboracion.Id }, centrosElaboracion);
        }

        // DELETE: api/CentrosElaboraciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CentrosElaboracion>> DeleteCentrosElaboracion(Guid id)
        {
            var centrosElaboracion = await _context.CentrosElaboracion.FindAsync(id);
            if (centrosElaboracion == null)
            {
                return NotFound();
            }

            _context.CentrosElaboracion.Remove(centrosElaboracion);
            await _context.SaveChangesAsync();

            return centrosElaboracion;
        }

        private bool CentrosElaboracionExists(Guid id)
        {
            return _context.CentrosElaboracion.Any(e => e.Id == id);
        }
    }
}

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
    public class UbicacionesController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public UbicacionesController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/Ubicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicacion()
        {
            return await _context.Ubicacion.ToListAsync();
        }

        // GET: api/Ubicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(Guid id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);

            if (ubicacion == null)
            {
                return NotFound();
            }

            return ubicacion;
        }

        // PUT: api/Ubicaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion(Guid id, Ubicacion ubicacion)
        {
            if (id != ubicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> PostUbicacion(Ubicacion ubicacion)
        {
            _context.Ubicacion.Add(ubicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacion", new { id = ubicacion.Id }, ubicacion);
        }

        // DELETE: api/Ubicaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ubicacion>> DeleteUbicacion(Guid id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            _context.Ubicacion.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return ubicacion;
        }

        private bool UbicacionExists(Guid id)
        {
            return _context.Ubicacion.Any(e => e.Id == id);
        }
    }
}

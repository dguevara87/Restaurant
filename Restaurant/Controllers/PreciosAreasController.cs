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
    public class PreciosAreasController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public PreciosAreasController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/PreciosAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreciosAreas>>> GetPreciosAreas()
        {
            return await _context.PreciosAreas.ToListAsync();
        }

        // GET: api/PreciosAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreciosAreas>> GetPreciosAreas(Guid id)
        {
            var preciosAreas = await _context.PreciosAreas.FindAsync(id);

            if (preciosAreas == null)
            {
                return NotFound();
            }

            return preciosAreas;
        }

        // PUT: api/PreciosAreas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreciosAreas(Guid id, PreciosAreas preciosAreas)
        {
            if (id != preciosAreas.Id)
            {
                return BadRequest();
            }

            _context.Entry(preciosAreas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreciosAreasExists(id))
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

        // POST: api/PreciosAreas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreciosAreas>> PostPreciosAreas(PreciosAreas preciosAreas)
        {
            _context.PreciosAreas.Add(preciosAreas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreciosAreas", new { id = preciosAreas.Id }, preciosAreas);
        }

        // DELETE: api/PreciosAreas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreciosAreas>> DeletePreciosAreas(Guid id)
        {
            var preciosAreas = await _context.PreciosAreas.FindAsync(id);
            if (preciosAreas == null)
            {
                return NotFound();
            }

            _context.PreciosAreas.Remove(preciosAreas);
            await _context.SaveChangesAsync();

            return preciosAreas;
        }

        private bool PreciosAreasExists(Guid id)
        {
            return _context.PreciosAreas.Any(e => e.Id == id);
        }
    }
}

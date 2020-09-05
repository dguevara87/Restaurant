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
    public class AreasCentrosElabsController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public AreasCentrosElabsController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/AreasCentrosElabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaCentroElab>>> GetAreaCentroElab()
        {
            return await _context.AreaCentroElab.ToListAsync();
        }

        // GET: api/AreasCentrosElabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaCentroElab>> GetAreaCentroElab(Guid id)
        {
            var areaCentroElab = await _context.AreaCentroElab.FindAsync(id);

            if (areaCentroElab == null)
            {
                return NotFound();
            }

            return areaCentroElab;
        }

        // PUT: api/AreasCentrosElabs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaCentroElab(Guid id, AreaCentroElab areaCentroElab)
        {
            if (id != areaCentroElab.Id)
            {
                return BadRequest();
            }

            _context.Entry(areaCentroElab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaCentroElabExists(id))
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

        // POST: api/AreasCentrosElabs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AreaCentroElab>> PostAreaCentroElab(AreaCentroElab areaCentroElab)
        {
            _context.AreaCentroElab.Add(areaCentroElab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreaCentroElab", new { id = areaCentroElab.Id }, areaCentroElab);
        }

        // DELETE: api/AreasCentrosElabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AreaCentroElab>> DeleteAreaCentroElab(Guid id)
        {
            var areaCentroElab = await _context.AreaCentroElab.FindAsync(id);
            if (areaCentroElab == null)
            {
                return NotFound();
            }

            _context.AreaCentroElab.Remove(areaCentroElab);
            await _context.SaveChangesAsync();

            return areaCentroElab;
        }

        private bool AreaCentroElabExists(Guid id)
        {
            return _context.AreaCentroElab.Any(e => e.Id == id);
        }
    }
}

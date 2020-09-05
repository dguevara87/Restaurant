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
    public class MesasController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public MesasController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/Mesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesas>>> GetMesas()
        {
            return await _context.Mesas.ToListAsync();
        }

        // GET: api/Mesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mesas>> GetMesas(Guid id)
        {
            var mesas = await _context.Mesas.FindAsync(id);

            if (mesas == null)
            {
                return NotFound();
            }

            return mesas;
        }

        // PUT: api/Mesas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesas(Guid id, Mesas mesas)
        {
            if (id != mesas.Id)
            {
                return BadRequest();
            }

            _context.Entry(mesas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesasExists(id))
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

        // POST: api/Mesas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mesas>> PostMesas(Mesas mesas)
        {
            _context.Mesas.Add(mesas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesas", new { id = mesas.Id }, mesas);
        }

        // DELETE: api/Mesas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mesas>> DeleteMesas(Guid id)
        {
            var mesas = await _context.Mesas.FindAsync(id);
            if (mesas == null)
            {
                return NotFound();
            }

            _context.Mesas.Remove(mesas);
            await _context.SaveChangesAsync();

            return mesas;
        }

        private bool MesasExists(Guid id)
        {
            return _context.Mesas.Any(e => e.Id == id);
        }
    }
}

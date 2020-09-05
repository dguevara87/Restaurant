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
    public class ReservasController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public ReservasController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservas>>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservas>> GetReservas(Guid id)
        {
            var reservas = await _context.Reservas.FindAsync(id);

            if (reservas == null)
            {
                return NotFound();
            }

            return reservas;
        }

        // PUT: api/Reservas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservas(Guid id, Reservas reservas)
        {
            if (id != reservas.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservasExists(id))
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

        // POST: api/Reservas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reservas>> PostReservas(Reservas reservas)
        {
            _context.Reservas.Add(reservas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservas", new { id = reservas.Id }, reservas);
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservas>> DeleteReservas(Guid id)
        {
            var reservas = await _context.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reservas);
            await _context.SaveChangesAsync();

            return reservas;
        }

        private bool ReservasExists(Guid id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}

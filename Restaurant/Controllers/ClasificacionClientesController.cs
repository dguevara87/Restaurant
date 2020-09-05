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
    public class ClasificacionClientesController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public ClasificacionClientesController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/ClasificacionClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasificacionClientes>>> GetClasificacionClientes()
        {
            return await _context.ClasificacionClientes.ToListAsync();
        }

        // GET: api/ClasificacionClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClasificacionClientes>> GetClasificacionClientes(Guid id)
        {
            var clasificacionClientes = await _context.ClasificacionClientes.FindAsync(id);

            if (clasificacionClientes == null)
            {
                return NotFound();
            }

            return clasificacionClientes;
        }

        // PUT: api/ClasificacionClientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasificacionClientes(Guid id, ClasificacionClientes clasificacionClientes)
        {
            if (id != clasificacionClientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(clasificacionClientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasificacionClientesExists(id))
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

        // POST: api/ClasificacionClientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClasificacionClientes>> PostClasificacionClientes(ClasificacionClientes clasificacionClientes)
        {
            _context.ClasificacionClientes.Add(clasificacionClientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasificacionClientes", new { id = clasificacionClientes.Id }, clasificacionClientes);
        }

        // DELETE: api/ClasificacionClientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClasificacionClientes>> DeleteClasificacionClientes(Guid id)
        {
            var clasificacionClientes = await _context.ClasificacionClientes.FindAsync(id);
            if (clasificacionClientes == null)
            {
                return NotFound();
            }

            _context.ClasificacionClientes.Remove(clasificacionClientes);
            await _context.SaveChangesAsync();

            return clasificacionClientes;
        }

        private bool ClasificacionClientesExists(Guid id)
        {
            return _context.ClasificacionClientes.Any(e => e.Id == id);
        }
    }
}

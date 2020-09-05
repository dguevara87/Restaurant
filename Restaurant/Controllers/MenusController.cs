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
    public class MenusController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public MenusController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menus>>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menus>> GetMenus(Guid id)
        {
            var menus = await _context.Menus.FindAsync(id);

            if (menus == null)
            {
                return NotFound();
            }

            return menus;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenus(Guid id, Menus menus)
        {
            if (id != menus.Id)
            {
                return BadRequest();
            }

            _context.Entry(menus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenusExists(id))
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

        // POST: api/Menus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Menus>> PostMenus(Menus menus)
        {
            _context.Menus.Add(menus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenus", new { id = menus.Id }, menus);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Menus>> DeleteMenus(Guid id)
        {
            var menus = await _context.Menus.FindAsync(id);
            if (menus == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menus);
            await _context.SaveChangesAsync();

            return menus;
        }

        private bool MenusExists(Guid id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}

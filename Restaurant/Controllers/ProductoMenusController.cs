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
    public class ProductoMenusController : ControllerBase
    {
        private readonly Restaurant1Context _context;

        public ProductoMenusController(Restaurant1Context context)
        {
            _context = context;
        }

        // GET: api/ProductoMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoMenu>>> GetProductoMenu()
        {
            return await _context.ProductoMenu.ToListAsync();
        }

        // GET: api/ProductoMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoMenu>> GetProductoMenu(Guid id)
        {
            var productoMenu = await _context.ProductoMenu.FindAsync(id);

            if (productoMenu == null)
            {
                return NotFound();
            }

            return productoMenu;
        }

        // PUT: api/ProductoMenus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoMenu(Guid id, ProductoMenu productoMenu)
        {
            if (id != productoMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(productoMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoMenuExists(id))
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

        // POST: api/ProductoMenus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductoMenu>> PostProductoMenu(ProductoMenu productoMenu)
        {
            _context.ProductoMenu.Add(productoMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoMenu", new { id = productoMenu.Id }, productoMenu);
        }

        // DELETE: api/ProductoMenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoMenu>> DeleteProductoMenu(Guid id)
        {
            var productoMenu = await _context.ProductoMenu.FindAsync(id);
            if (productoMenu == null)
            {
                return NotFound();
            }

            _context.ProductoMenu.Remove(productoMenu);
            await _context.SaveChangesAsync();

            return productoMenu;
        }

        private bool ProductoMenuExists(Guid id)
        {
            return _context.ProductoMenu.Any(e => e.Id == id);
        }
    }
}

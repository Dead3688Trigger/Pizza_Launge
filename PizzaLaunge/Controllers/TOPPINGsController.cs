using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace PizzaLaunge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TOPPINGsController : ControllerBase
    {
        private readonly PizzaContext _context;

        public TOPPINGsController(PizzaContext context)
        {
            _context = context;
        }

        // GET: api/TOPPINGs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TOPPING>>> GetTOPPINGS()
        {
            return await _context.TOPPINGS.ToListAsync();
        }

        // GET: api/TOPPINGs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TOPPING>> GetTOPPING(string id)
        {
            var tOPPING = await _context.TOPPINGS.FindAsync(id);

            if (tOPPING == null)
            {
                return NotFound();
            }

            return tOPPING;
        }

        // PUT: api/TOPPINGs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTOPPING(string id, TOPPING tOPPING)
        {
            if (id != tOPPING.ToppingID)
            {
                return BadRequest();
            }

            _context.Entry(tOPPING).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TOPPINGExists(id))
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

        // POST: api/TOPPINGs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TOPPING>> PostTOPPING(TOPPING tOPPING)
        {
            _context.TOPPINGS.Add(tOPPING);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TOPPINGExists(tOPPING.ToppingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTOPPING", new { id = tOPPING.ToppingID }, tOPPING);
        }

        // DELETE: api/TOPPINGs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTOPPING(string id)
        {
            var tOPPING = await _context.TOPPINGS.FindAsync(id);
            if (tOPPING == null)
            {
                return NotFound();
            }

            _context.TOPPINGS.Remove(tOPPING);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TOPPINGExists(string id)
        {
            return _context.TOPPINGS.Any(e => e.ToppingID == id);
        }
    }
}

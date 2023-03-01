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
    public class PIZZAsController : ControllerBase
    {
        private readonly PizzaContext _context;

        public PIZZAsController(PizzaContext context)
        {
            _context = context;
        }

        // GET: api/PIZZAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PIZZA>>> GetPIZZAs()
        {
            return await _context.PIZZAs.ToListAsync();
        }

        // GET: api/PIZZAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PIZZA>> GetPIZZA(string id)
        {
            var pIZZA = await _context.PIZZAs.FindAsync(id);

            if (pIZZA == null)
            {
                return NotFound();
            }

            return pIZZA;
        }

        // PUT: api/PIZZAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPIZZA(string id, PIZZA pIZZA)
        {
            if (id != pIZZA.PizzaID)
            {
                return BadRequest();
            }

            _context.Entry(pIZZA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PIZZAExists(id))
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

        // POST: api/PIZZAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PIZZA>> PostPIZZA(PIZZA pIZZA)
        {
            _context.PIZZAs.Add(pIZZA);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PIZZAExists(pIZZA.PizzaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPIZZA", new { id = pIZZA.PizzaID }, pIZZA);
        }

        // DELETE: api/PIZZAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePIZZA(string id)
        {
            var pIZZA = await _context.PIZZAs.FindAsync(id);
            if (pIZZA == null)
            {
                return NotFound();
            }

            _context.PIZZAs.Remove(pIZZA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PIZZAExists(string id)
        {
            return _context.PIZZAs.Any(e => e.PizzaID == id);
        }
    }
}

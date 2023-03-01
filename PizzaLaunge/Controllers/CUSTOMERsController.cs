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
    public class CUSTOMERsController : ControllerBase
    {
        private readonly PizzaContext _context;

        public CUSTOMERsController(PizzaContext context)
        {
            _context = context;
        }

        // GET: api/CUSTOMERs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CUSTOMER>>> GetCUSTOMERs()
        {
            return await _context.CUSTOMERs.ToListAsync();
        }

        // GET: api/CUSTOMERs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CUSTOMER>> GetCUSTOMER(string id)
        {
            var cUSTOMER = await _context.CUSTOMERs.FindAsync(id);

            if (cUSTOMER == null)
            {
                return NotFound();
            }

            return cUSTOMER;
        }

        // PUT: api/CUSTOMERs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCUSTOMER(string id, CUSTOMER cUSTOMER)
        {
            if (id != cUSTOMER.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(cUSTOMER).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUSTOMERExists(id))
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

        // POST: api/CUSTOMERs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CUSTOMER>> PostCUSTOMER(CUSTOMER cUSTOMER)
        {
            _context.CUSTOMERs.Add(cUSTOMER);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CUSTOMERExists(cUSTOMER.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCUSTOMER", new { id = cUSTOMER.CustomerId }, cUSTOMER);
        }

        // DELETE: api/CUSTOMERs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCUSTOMER(string id)
        {
            var cUSTOMER = await _context.CUSTOMERs.FindAsync(id);
            if (cUSTOMER == null)
            {
                return NotFound();
            }

            _context.CUSTOMERs.Remove(cUSTOMER);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CUSTOMERExists(string id)
        {
            return _context.CUSTOMERs.Any(e => e.CustomerId == id);
        }
    }
}

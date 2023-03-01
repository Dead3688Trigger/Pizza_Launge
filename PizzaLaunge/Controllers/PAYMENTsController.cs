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
    public class PAYMENTsController : ControllerBase
    {
        private readonly PizzaContext _context;

        public PAYMENTsController(PizzaContext context)
        {
            _context = context;
        }

        // GET: api/PAYMENTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PAYMENT>>> GetPAYMENTs()
        {
            return await _context.PAYMENTs.ToListAsync();
        }

        // GET: api/PAYMENTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PAYMENT>> GetPAYMENT(string id)
        {
            var pAYMENT = await _context.PAYMENTs.FindAsync(id);

            if (pAYMENT == null)
            {
                return NotFound();
            }

            return pAYMENT;
        }

        // PUT: api/PAYMENTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPAYMENT(string id, PAYMENT pAYMENT)
        {
            if (id != pAYMENT.PaymentID)
            {
                return BadRequest();
            }

            _context.Entry(pAYMENT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PAYMENTExists(id))
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

        // POST: api/PAYMENTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PAYMENT>> PostPAYMENT(PAYMENT pAYMENT)
        {
            _context.PAYMENTs.Add(pAYMENT);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PAYMENTExists(pAYMENT.PaymentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPAYMENT", new { id = pAYMENT.PaymentID }, pAYMENT);
        }

        // DELETE: api/PAYMENTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePAYMENT(string id)
        {
            var pAYMENT = await _context.PAYMENTs.FindAsync(id);
            if (pAYMENT == null)
            {
                return NotFound();
            }

            _context.PAYMENTs.Remove(pAYMENT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PAYMENTExists(string id)
        {
            return _context.PAYMENTs.Any(e => e.PaymentID == id);
        }
    }
}

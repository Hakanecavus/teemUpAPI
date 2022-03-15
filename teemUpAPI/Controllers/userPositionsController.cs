#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teemUpAPI.Data;
using teemUpAPI.Models;

namespace teemUpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userPositionsController : ControllerBase
    {
        private readonly DataContext _context;

        public userPositionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/userPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userPositions>>> GetuserPositions()
        {
            return await _context.userPositions.ToListAsync();
        }

        // GET: api/userPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<userPositions>> GetuserPositions(int id)
        {
            var userPositions = await _context.userPositions.FindAsync(id);

            if (userPositions == null)
            {
                return NotFound();
            }

            return userPositions;
        }

        // PUT: api/userPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutuserPositions(int id, userPositions userPositions)
        {
            if (id != userPositions.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPositions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userPositionsExists(id))
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

        // POST: api/userPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<userPositions>> PostuserPositions(userPositions userPositions)
        {
            _context.userPositions.Add(userPositions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetuserPositions", new { id = userPositions.Id }, userPositions);
        }

        // DELETE: api/userPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteuserPositions(int id)
        {
            var userPositions = await _context.userPositions.FindAsync(id);
            if (userPositions == null)
            {
                return NotFound();
            }

            _context.userPositions.Remove(userPositions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userPositionsExists(int id)
        {
            return _context.userPositions.Any(e => e.Id == id);
        }
    }
}

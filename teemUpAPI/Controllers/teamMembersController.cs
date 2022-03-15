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
    public class teamMembersController : ControllerBase
    {
        private readonly DataContext _context;

        public teamMembersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/teamMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<teamMembers>>> GetteamMembers()
        {
            return await _context.teamMembers.ToListAsync();
        }

        // GET: api/teamMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<teamMembers>> GetteamMembers(int id)
        {
            var teamMembers = await _context.teamMembers.FindAsync(id);

            if (teamMembers == null)
            {
                return NotFound();
            }

            return teamMembers;
        }

        // PUT: api/teamMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutteamMembers(int id, teamMembers teamMembers)
        {
            if (id != teamMembers.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teamMembersExists(id))
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

        // POST: api/teamMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<teamMembers>> PostteamMembers(teamMembers teamMembers)
        {
            _context.teamMembers.Add(teamMembers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetteamMembers", new { id = teamMembers.Id }, teamMembers);
        }

        // DELETE: api/teamMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteteamMembers(int id)
        {
            var teamMembers = await _context.teamMembers.FindAsync(id);
            if (teamMembers == null)
            {
                return NotFound();
            }

            _context.teamMembers.Remove(teamMembers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool teamMembersExists(int id)
        {
            return _context.teamMembers.Any(e => e.Id == id);
        }
    }
}

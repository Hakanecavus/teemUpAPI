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
    public class TeamsController : ControllerBase
    {
        private readonly DataContext _context;

        public TeamsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teams>>> Getteams()
        {
            return await _context.teams.ToListAsync();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teams>> GetTeams(int id)
        {
            var teams = await _context.teams.FindAsync(id);

            if (teams == null)
            {
                return NotFound();
            }

            return teams;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeams(int id, Teams teams)
        {
            if (id != teams.teamId)
            {
                return BadRequest();
            }

            _context.Entry(teams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamsExists(id))
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

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teams>> PostTeams(Teams teams)
        {
            _context.teams.Add(teams);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeams", new { id = teams.teamId }, teams);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeams(int id)
        {
            var teams = await _context.teams.FindAsync(id);
            if (teams == null)
            {
                return NotFound();
            }

            _context.teams.Remove(teams);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamsExists(int id)
        {
            return _context.teams.Any(e => e.teamId == id);
        }
    }
}

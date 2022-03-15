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
    public class licensesController : ControllerBase
    {
        private readonly DataContext _context;

        public licensesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/licenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<license>>> Getlicense()
        {
            return await _context.license.ToListAsync();
        }

        // GET: api/licenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<license>> Getlicense(int id)
        {
            var license = await _context.license.FindAsync(id);

            if (license == null)
            {
                return NotFound();
            }

            return license;
        }

        // PUT: api/licenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlicense(int id, license license)
        {
            if (id != license.Id)
            {
                return BadRequest();
            }

            _context.Entry(license).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!licenseExists(id))
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

        // POST: api/licenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<license>> Postlicense(license license)
        {
            _context.license.Add(license);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlicense", new { id = license.Id }, license);
        }

        // DELETE: api/licenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelicense(int id)
        {
            var license = await _context.license.FindAsync(id);
            if (license == null)
            {
                return NotFound();
            }

            _context.license.Remove(license);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool licenseExists(int id)
        {
            return _context.license.Any(e => e.Id == id);
        }
    }
}

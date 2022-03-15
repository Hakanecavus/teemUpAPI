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
    public class licenseTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public licenseTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/licenseTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<licenseTypes>>> GetlicenseTypes()
        {
            return await _context.licenseTypes.ToListAsync();
        }

        // GET: api/licenseTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<licenseTypes>> GetlicenseTypes(int id)
        {
            var licenseTypes = await _context.licenseTypes.FindAsync(id);

            if (licenseTypes == null)
            {
                return NotFound();
            }

            return licenseTypes;
        }

        // PUT: api/licenseTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutlicenseTypes(int id, licenseTypes licenseTypes)
        {
            if (id != licenseTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(licenseTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!licenseTypesExists(id))
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

        // POST: api/licenseTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<licenseTypes>> PostlicenseTypes(licenseTypes licenseTypes)
        {
            _context.licenseTypes.Add(licenseTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetlicenseTypes", new { id = licenseTypes.Id }, licenseTypes);
        }

        // DELETE: api/licenseTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletelicenseTypes(int id)
        {
            var licenseTypes = await _context.licenseTypes.FindAsync(id);
            if (licenseTypes == null)
            {
                return NotFound();
            }

            _context.licenseTypes.Remove(licenseTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool licenseTypesExists(int id)
        {
            return _context.licenseTypes.Any(e => e.Id == id);
        }
    }
}

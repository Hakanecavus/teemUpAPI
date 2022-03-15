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
    public class dutyTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public dutyTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/dutyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dutyTypes>>> GetdutyTypes()
        {
            return await _context.dutyTypes.ToListAsync();
        }

        // GET: api/dutyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dutyTypes>> GetdutyTypes(int id)
        {
            var dutyTypes = await _context.dutyTypes.FindAsync(id);

            if (dutyTypes == null)
            {
                return NotFound();
            }

            return dutyTypes;
        }

        // PUT: api/dutyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdutyTypes(int id, dutyTypes dutyTypes)
        {
            if (id != dutyTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(dutyTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dutyTypesExists(id))
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

        // POST: api/dutyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<dutyTypes>> PostdutyTypes(dutyTypes dutyTypes)
        {
            _context.dutyTypes.Add(dutyTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdutyTypes", new { id = dutyTypes.Id }, dutyTypes);
        }

        // DELETE: api/dutyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedutyTypes(int id)
        {
            var dutyTypes = await _context.dutyTypes.FindAsync(id);
            if (dutyTypes == null)
            {
                return NotFound();
            }

            _context.dutyTypes.Remove(dutyTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool dutyTypesExists(int id)
        {
            return _context.dutyTypes.Any(e => e.Id == id);
        }
    }
}

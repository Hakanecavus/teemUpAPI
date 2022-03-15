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
    public class taskAssignmentsController : ControllerBase
    {
        private readonly DataContext _context;

        public taskAssignmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/taskAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<taskAssignment>>> GettaskAssignment()
        {
            return await _context.taskAssignment.ToListAsync();
        }

        // GET: api/taskAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<taskAssignment>> GettaskAssignment(int id)
        {
            var taskAssignment = await _context.taskAssignment.FindAsync(id);

            if (taskAssignment == null)
            {
                return NotFound();
            }

            return taskAssignment;
        }

        // PUT: api/taskAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttaskAssignment(int id, taskAssignment taskAssignment)
        {
            if (id != taskAssignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taskAssignmentExists(id))
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

        // POST: api/taskAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<taskAssignment>> PosttaskAssignment(taskAssignment taskAssignment)
        {
            _context.taskAssignment.Add(taskAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettaskAssignment", new { id = taskAssignment.Id }, taskAssignment);
        }

        // DELETE: api/taskAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetaskAssignment(int id)
        {
            var taskAssignment = await _context.taskAssignment.FindAsync(id);
            if (taskAssignment == null)
            {
                return NotFound();
            }

            _context.taskAssignment.Remove(taskAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool taskAssignmentExists(int id)
        {
            return _context.taskAssignment.Any(e => e.Id == id);
        }
    }
}

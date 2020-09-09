using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _25.Core.System;
using _25.Data.Context;

namespace INF_370.Group._25.ASP.NET.Core.API.Controllers.Scaffolds
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSystemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubSystemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubSystems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubSystem>>> GetSubSystems()
        {
            return await _context.SubSystems.ToListAsync();
        }

        // GET: api/SubSystems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubSystem>> GetSubSystem(int id)
        {
            var subSystem = await _context.SubSystems.FindAsync(id);

            if (subSystem == null)
            {
                return NotFound();
            }

            return subSystem;
        }

        // PUT: api/SubSystems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubSystem(int id, SubSystem subSystem)
        {
            if (id != subSystem.SubSystemId)
            {
                return BadRequest();
            }

            _context.Entry(subSystem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubSystemExists(id))
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

        // POST: api/SubSystems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SubSystem>> PostSubSystem(SubSystem subSystem)
        {
            _context.SubSystems.Add(subSystem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubSystem", new { id = subSystem.SubSystemId }, subSystem);
        }

        // DELETE: api/SubSystems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubSystem>> DeleteSubSystem(int id)
        {
            var subSystem = await _context.SubSystems.FindAsync(id);
            if (subSystem == null)
            {
                return NotFound();
            }

            _context.SubSystems.Remove(subSystem);
            await _context.SaveChangesAsync();

            return subSystem;
        }

        private bool SubSystemExists(int id)
        {
            return _context.SubSystems.Any(e => e.SubSystemId == id);
        }
    }
}

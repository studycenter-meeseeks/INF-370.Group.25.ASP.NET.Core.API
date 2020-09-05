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
    public class SystemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemsController(ApplicationDbContext context)
        { 
            _context = context;
        }

        // GET: api/Systems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<global::_25.Core.System.System>>> GetSystems()
        {
            return await _context.Systems.ToListAsync();
        }

        // GET: api/Systems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<global::_25.Core.System.System>> GetSystem(int id)
        {
            var system = await _context.Systems.FindAsync(id);

            if (system == null)
            {
                return NotFound();
            }

            return system;
        }

        // PUT: api/Systems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystem(int id, global::_25.Core.System.System system)
        {
            if (id != system.SystemId)
            {
                return BadRequest();
            }

            _context.Entry(system).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemExists(id))
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

        // POST: api/Systems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<global::_25.Core.System.System>> PostSystem(global::_25.Core.System.System system)
        {
            _context.Systems.Add(system);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystem", new { id = system.SystemId }, system);
        }

        // DELETE: api/Systems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<global::_25.Core.System.System>> DeleteSystem(int id)
        {
            var system = await _context.Systems.FindAsync(id);
            if (system == null)
            {
                return NotFound();
            }

            _context.Systems.Remove(system);
            await _context.SaveChangesAsync();

            return system;
        }

        private bool SystemExists(int id)
        {
            return _context.Systems.Any(e => e.SystemId == id);
        }
    }
}

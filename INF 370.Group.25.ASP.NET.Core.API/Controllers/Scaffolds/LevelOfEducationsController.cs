using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _25.Core.User;
using _25.Data.Context;

namespace INF_370.Group._25.ASP.NET.Core.API.Controllers.Scaffolds
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelOfEducationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LevelOfEducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LevelOfEducations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelOfEducation>>> GetLevelOfEducations()
        {
            return await _context.LevelOfEducations.ToListAsync();
        }

        // GET: api/LevelOfEducations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelOfEducation>> GetLevelOfEducation(int id)
        {
            var levelOfEducation = await _context.LevelOfEducations.FindAsync(id);

            if (levelOfEducation == null)
            {
                return NotFound();
            }

            return levelOfEducation;
        }

        // PUT: api/LevelOfEducations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevelOfEducation(int id, LevelOfEducation levelOfEducation)
        {
            if (id != levelOfEducation.LevelOfEducationId)
            {
                return BadRequest();
            }

            _context.Entry(levelOfEducation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelOfEducationExists(id))
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

        // POST: api/LevelOfEducations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LevelOfEducation>> PostLevelOfEducation(LevelOfEducation levelOfEducation)
        {
            _context.LevelOfEducations.Add(levelOfEducation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevelOfEducation", new { id = levelOfEducation.LevelOfEducationId }, levelOfEducation);
        }

        // DELETE: api/LevelOfEducations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LevelOfEducation>> DeleteLevelOfEducation(int id)
        {
            var levelOfEducation = await _context.LevelOfEducations.FindAsync(id);
            if (levelOfEducation == null)
            {
                return NotFound();
            }

            _context.LevelOfEducations.Remove(levelOfEducation);
            await _context.SaveChangesAsync();

            return levelOfEducation;
        }

        private bool LevelOfEducationExists(int id)
        {
            return _context.LevelOfEducations.Any(e => e.LevelOfEducationId == id);
        }
    }
}

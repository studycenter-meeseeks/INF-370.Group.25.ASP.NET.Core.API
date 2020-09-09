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
    public class HomeLanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeLanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HomeLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeLanguage>>> GetHomeLanguages()
        {
            return await _context.HomeLanguages.ToListAsync();
        }

        // GET: api/HomeLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeLanguage>> GetHomeLanguage(int id)
        {
            var homeLanguage = await _context.HomeLanguages.FindAsync(id);

            if (homeLanguage == null)
            {
                return NotFound();
            }

            return homeLanguage;
        }

        // PUT: api/HomeLanguages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeLanguage(int id, HomeLanguage homeLanguage)
        {
            if (id != homeLanguage.HomeLanguageId)
            {
                return BadRequest();
            }

            _context.Entry(homeLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeLanguageExists(id))
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

        // POST: api/HomeLanguages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HomeLanguage>> PostHomeLanguage(HomeLanguage homeLanguage)
        {
            _context.HomeLanguages.Add(homeLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeLanguage", new { id = homeLanguage.HomeLanguageId }, homeLanguage);
        }

        // DELETE: api/HomeLanguages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HomeLanguage>> DeleteHomeLanguage(int id)
        {
            var homeLanguage = await _context.HomeLanguages.FindAsync(id);
            if (homeLanguage == null)
            {
                return NotFound();
            }

            _context.HomeLanguages.Remove(homeLanguage);
            await _context.SaveChangesAsync();

            return homeLanguage;
        }

        private bool HomeLanguageExists(int id)
        {
            return _context.HomeLanguages.Any(e => e.HomeLanguageId == id);
        }
    }
}

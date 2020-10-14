using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresetApi.Models;

namespace PresetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresetsController : ControllerBase
    {
        private readonly PresetApiContext _context;

        public PresetsController(PresetApiContext context)
        {
            _context = context;
        }

        // GET: api/Presets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preset>>> GetPresets()
        {
            return await _context.Presets.ToListAsync();
        }

        // GET: api/Presets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preset>> GetPreset(int id)
        {
            var preset = await _context.Presets.FindAsync(id);

            if (preset == null)
            {
                return NotFound();
            }

            return preset;
        }

        // PUT: api/Presets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreset(int id, Preset preset)
        {
            if (id != preset.id)
            {
                return BadRequest();
            }

            _context.Entry(preset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresetExists(id))
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

        // POST: api/Presets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Preset>> PostPreset(Preset preset)
        {
            _context.Presets.Add(preset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreset", new { id = preset.id }, preset);
        }

        // DELETE: api/Presets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Preset>> DeletePreset(int id)
        {
            var preset = await _context.Presets.FindAsync(id);
            if (preset == null)
            {
                return NotFound();
            }

            _context.Presets.Remove(preset);
            await _context.SaveChangesAsync();

            return preset;
        }

        private bool PresetExists(int id)
        {
            return _context.Presets.Any(e => e.id == id);
        }
    }
}

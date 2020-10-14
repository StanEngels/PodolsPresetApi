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
    public class EffectToPresetsController : ControllerBase
    {
        private readonly PresetApiContext _context;

        public EffectToPresetsController(PresetApiContext context)
        {
            _context = context;
        }

        // GET: api/EffectToPresets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EffectToPreset>>> GetEffectsToPresets()
        {
            return await _context.EffectsToPresets.ToListAsync();
        }

        // GET: api/EffectToPresets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EffectToPreset>> GetEffectToPreset(int id)
        {
            var effectToPreset = await _context.EffectsToPresets.FindAsync(id);

            if (effectToPreset == null)
            {
                return NotFound();
            }

            return effectToPreset;
        }

        // PUT: api/EffectToPresets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEffectToPreset(int id, EffectToPreset effectToPreset)
        {
            if (id != effectToPreset.id)
            {
                return BadRequest();
            }

            _context.Entry(effectToPreset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EffectToPresetExists(id))
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

        // POST: api/EffectToPresets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EffectToPreset>> PostEffectToPreset(EffectToPreset effectToPreset)
        {
            _context.EffectsToPresets.Add(effectToPreset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEffectToPreset", new { id = effectToPreset.id }, effectToPreset);
        }

        // DELETE: api/EffectToPresets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EffectToPreset>> DeleteEffectToPreset(int id)
        {
            var effectToPreset = await _context.EffectsToPresets.FindAsync(id);
            if (effectToPreset == null)
            {
                return NotFound();
            }

            _context.EffectsToPresets.Remove(effectToPreset);
            await _context.SaveChangesAsync();

            return effectToPreset;
        }

        private bool EffectToPresetExists(int id)
        {
            return _context.EffectsToPresets.Any(e => e.id == id);
        }
    }
}

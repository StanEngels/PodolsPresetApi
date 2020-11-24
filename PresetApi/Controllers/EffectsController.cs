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
    public class EffectsController : ControllerBase
    {
        private readonly PresetApiContext _context;

        public EffectsController(PresetApiContext context)
        {
            _context = context;
        }

        // GET: api/Effects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Effect>>> GetEffects()
        {
            return await _context.Effects.ToListAsync();
        }

        // GET: api/Effects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Effect>> GetEffect(int id)
        {
            var effect = await _context.Effects.FindAsync(id);

            if (effect == null)
            {
                return NotFound();
            }

            return effect;
        }

        // PUT: api/Effects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEffect(int id, Effect effect)
        {
            if (id != effect.id)
            {
                return BadRequest();
            }

            _context.Entry(effect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EffectExists(id))
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

        // POST: api/Effects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Effect>> PostEffect(Effect effect)
        {
            _context.Effects.Add(effect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEffect", new { id = effect.id }, effect);
        }

        // DELETE: api/Effects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Effect>> DeleteEffect(int id)
        {
            var effect = await _context.Effects.FindAsync(id);
            if (effect == null)
            {
                return NotFound();
            }

            _context.Effects.Remove(effect);
            await _context.SaveChangesAsync();

            return effect;
        }

        private bool EffectExists(int id)
        {
            return _context.Effects.Any(e => e.id == id);
        }
    }
}

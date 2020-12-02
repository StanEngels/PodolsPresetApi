using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresetApi.Interfaces;
using PresetApi.Models;

namespace PresetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresetsController : ControllerBase
    {
        private readonly IPresetDbAccess _presetDb;

        public PresetsController(IPresetDbAccess context)
        {
            _presetDb = context;
        }

        // GET: api/Presets
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Preset>>> GetPresets()
        {
            return await _presetDb.GetPresets();
        }

        // GET: api/Presets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preset>> GetPreset(int id)
        {
            var preset = await _presetDb.GetPreset(id);

            if (preset == null)
            {
                return NotFound();
            }

            return Ok(preset);
        }

        // POST: api/Presets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Preset>> PostPreset(Preset preset)
        {
            await _presetDb.PostPreset(preset);

            return CreatedAtAction("GetPreset", new { id = preset.id }, preset);
        }

        // DELETE: api/Presets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Preset>> DeletePreset(int id)
        {
            var preset = await _presetDb.PresetExists(id);
            if (preset == null)
            {
                return NotFound();
            }

            await _presetDb.DeletePreset(preset);

            return preset;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresetApi.Interfaces;
using PresetApi.Models;

namespace PresetApi.Classes
{
    public class PresetDbAcces : IPresetDbAccess
    {
        private readonly PresetApiContext _context;

        public PresetDbAcces(PresetApiContext context)
        {
            _context = context;
        }

        public async Task<List<Preset>> GetPresets()
        {
            return await _context.Presets.ToListAsync();
        }

        public async Task<Preset> GetPreset(int id)
        {
            return await _context.Presets.FindAsync(id);
        }

        public async Task<Preset> PostPreset(Preset preset)
        {
            _context.Presets.Add(preset);
            await _context.SaveChangesAsync();

            return preset;
        }

        public async Task<Preset> DeletePreset(Preset preset)
        {
            _context.Presets.Remove(preset);
            await _context.SaveChangesAsync();

            return preset;
        }

        public async Task<Preset> PresetExists(int id)
        {
            return await _context.Presets.FindAsync(id);
        }
    }
}

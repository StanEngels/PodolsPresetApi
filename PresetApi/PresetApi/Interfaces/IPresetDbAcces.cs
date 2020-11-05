using Microsoft.EntityFrameworkCore;
using PresetApi.Controllers;
using PresetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresetApi.Interfaces
{
    public interface IPresetDbAccess
    {
        public Task<List<Preset>> GetPresets();
        public Task<Preset> GetPreset(int id);
        public Task<Preset> PostPreset(Preset preset);
        public Task<Preset> DeletePreset(Preset preset);
        public Task<Preset> PresetExists(int id);
    }

}

using Microsoft.EntityFrameworkCore;

namespace PresetApi.Models
{
    public class PresetApiContext : DbContext
    {
        public PresetApiContext(DbContextOptions<PresetApiContext> options)
            : base(options)
        {
        }
        public DbSet<Preset> Presets { get; set; }
        public DbSet<EffectToPreset> EffectsToPresets { get; set; }
        public DbSet<Effect> Effects { get; set; }
    }
}

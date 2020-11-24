using System;

namespace PresetApi.Models
{
    public class EffectToPreset
    {
        public int id { get; set; }
        public Preset PresetId { get; set; }
        public Effect EffectId { get; set; }
    }
}

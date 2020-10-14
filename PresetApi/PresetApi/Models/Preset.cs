using System;

namespace PresetApi.Models
{
    public class Preset
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public string presetName { get; set; }
    }
}

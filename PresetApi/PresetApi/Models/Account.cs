using System;

namespace PresetApi.Models
{
    public class Account
    {
        public int id { get; set; }
        public string email { get; set; }
        public string hashedPassword { get; set; }
    }
}

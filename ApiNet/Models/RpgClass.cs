﻿namespace ApiNet.Models
{
    public class RpgClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Character> Characters { get; set; }
    }
}

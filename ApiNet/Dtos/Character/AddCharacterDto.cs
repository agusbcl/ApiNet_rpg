using ApiNet.Dtos.RpgClass;

namespace ApiNet.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = string.Empty;
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public int RpgClassId { get; set; }
    }
}

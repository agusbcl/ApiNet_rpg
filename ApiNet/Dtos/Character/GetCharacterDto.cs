using ApiNet.Dtos.Power;
using ApiNet.Dtos.RpgClass;

namespace ApiNet.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int HitPoints { get; set; } 
        public int Strength { get; set; } 
        public int Defense { get; set; } 
        public int Intelligence { get; set; }        
        public RpgClassDto RpgClass { get; set; }
        public List<PowerDto> Powers { get; set; }
        
    }
}

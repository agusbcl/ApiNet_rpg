namespace ApiNet.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public int RpgClassId { get; set; }
        public RpgClass RpgClass { get; set; }
        public List<Power> Powers { get; set; }
    }
}

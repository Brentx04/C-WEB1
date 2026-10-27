namespace MVCSportStore.Models
{
    public class Locatie
    {
        public int LocatieId { get; set; }
        public string Stad { get; set; } = string.Empty;
        public int LandId { get; set; }
        public ICollection<Afdeling>? Afdelingen { get; set; }
        public Land? Land { get; set; }
    }
}

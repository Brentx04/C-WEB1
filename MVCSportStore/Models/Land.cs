namespace MVCSportStore.Models
{
    public class Land
    {
        public int LandId { get; set; }
        public string LandCode { get; set; } = string.Empty;
        public string LandNaam { get; set; } = string.Empty;
        public ICollection<Locatie>? Locaties { get; set; }
    }
}

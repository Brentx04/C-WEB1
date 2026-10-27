namespace MVCSportStore.Models
{
    public class Afdeling
    {
        public int AfdelingId { get; set; }
        public string AfdelingNaam { get; set; } = string.Empty;
        public int LocatieId { get; set; }
        public Locatie? Locatie { get; set; }
    }
}

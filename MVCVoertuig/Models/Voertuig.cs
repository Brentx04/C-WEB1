using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVCVoertuig.Validation;

namespace MVCVoertuig.Models
{
    // Stap 5 - Model Voertuig
    // EF Core maakt hiervan de tabel "Voertuigen" (naam van de DbSet in VoertuigDbContext).
    public class Voertuig
    {
        // "<Klassenaam>Id" -> EF Core ziet dit automatisch als PRIMARY KEY (identity)
        public int VoertuigId { get; set; }

        [Required(ErrorMessage = "Merk is verplicht")]
        [StringLength(100)]                 // -> nvarchar(100) in de databank
        public string Merk { get; set; } = string.Empty;

        [Required(ErrorMessage = "MerkType is verplicht")]
        [StringLength(100)]
        public string MerkType { get; set; } = string.Empty;

        // Stap 6 - Custom validatie: tussen 1900 en het huidige jaar
        [Required(ErrorMessage = "Bouwjaar is verplicht")]
        [Bouwjaar]
        public int Bouwjaar { get; set; }

        [Required(ErrorMessage = "Km is verplicht")]
        [Range(0, 5000000, ErrorMessage = "Km moet tussen 0 en 5000000 liggen")]
        public int Km { get; set; }

        [Required(ErrorMessage = "VerkoopPrijs is verplicht")]
        [Column(TypeName = "decimal(8,2)")] // -> decimal(8,2) in de databank
        public decimal VerkoopPrijs { get; set; }

        // Niet verplicht: geen [Required]
        public bool AanwezigInShowroom { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MVCSportStore.ViewModels
{
    // Formulier-model voor de (extra) PagingSettingsPage
    public class PagingSettingsViewModel
    {
        [Required]
        [Range(1, 100, ErrorMessage = "Kies een waarde tussen 1 en 100.")]
        [Display(Name = "Producten per pagina")]
        public int ProductPagination { get; set; }
    }
}

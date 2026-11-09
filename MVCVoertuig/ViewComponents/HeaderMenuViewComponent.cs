using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;

namespace MVCVoertuig.ViewComponents
{
    // Stap 14 - ViewComponent: toont alle UNIEKE merken in het menu
    // Klassenaam HeaderMenuViewComponent -> aanroepen met  @await Component.InvokeAsync("HeaderMenu")
    //                                       of met tag     <vc:header-menu></vc:header-menu>
    // View staat in:  Views/Shared/Components/HeaderMenu/Default.cshtml
    public class HeaderMenuViewComponent : ViewComponent
    {
        private readonly VoertuigDbContext _context;

        public HeaderMenuViewComponent(VoertuigDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var merken = _context.Voertuigen
                .Select(v => v.Merk)
                .Distinct()          // enkel unieke merken
                .OrderBy(m => m)
                .ToList();

            return View(merken);     // -> Default.cshtml met model List<string>
        }
    }
}

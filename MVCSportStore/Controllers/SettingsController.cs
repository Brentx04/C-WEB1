using Microsoft.AspNetCore.Mvc;
using MVCSportStore.ViewModels;

namespace MVCSportStore.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new PagingSettingsViewModel
            {
                ProductPagination = PagingSettings.ProductPagination
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PagingSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            PagingSettings.ProductPagination = model.ProductPagination;
            PagingSettings.PagingSettingsPage = true; // instellingen zijn aangepast via de pagina

            return RedirectToAction("Index", "Home");
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCSportStore.Data;
using MVCSportStore.Models;
using MVCSportStore.ViewModels;

namespace MVCSportStore.Controllers
{
    public class HomeController : Controller
    {
        private StoreDbContext _context;

        public HomeController(StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int productPage = 1)
        {
            int pageItems = PagingSettings.ProductPagination;
            int totalItems = _context.Products.Count();

            int totalPages = Math.Max(1, (int)Math.Ceiling((decimal)totalItems / pageItems));
            productPage = Math.Clamp(productPage, 1, totalPages);

            var model = new ProductModel
            {
                Products = _context.Products
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * pageItems)
                    .Take(pageItems)
                    .ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    PageItems = pageItems,
                    TotalItems = totalItems
                }
            };

            return View(model);
        }

        // C# Web 16 - demo van FirstTagHelper, TitleTagHelper en BoldTagHelper
        public IActionResult TagHelpers()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Diagnostics;
using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductContext _context;

        public HomeController(ILogger<HomeController> logger, ProductContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Redirect root to the ProductList action
            return RedirectToAction("ProductList");
        }

        public IActionResult Privacy() => View();

        public async Task<IActionResult> ProductList()
        {
            var products = await _context.Products.OrderBy(p => p.Name).ToListAsync();
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}

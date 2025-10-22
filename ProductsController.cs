using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Controllers
{

    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        public ProductsController(ProductContext context) => _context = context;

        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = "Add";
                return View("Edit", product);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductList", "Home");
        }

        // GET: Products/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            ViewBag.Action = "Edit";
            return View(product);
        }

        // POST: Products/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.Action = "Edit";
                return View(product);
            }

            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("ProductList", "Home");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.ProductId == id)) return NotFound();
                throw;
            }
        }

        // GET: Products/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Products/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ProductList", "Home");
        }
    }
}
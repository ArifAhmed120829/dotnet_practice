using Microsoft.AspNetCore.Mvc;
using Ex.Infrastructure.Data;
using Ex.Domain.Entities;
using System.Linq;

namespace Ex.Web.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // LIST PRODUCTS
        [Route("")]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // CREATE PRODUCT (GET)
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE PRODUCT (POST)
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.UtcNow;
                product.UpdatedDate = DateTime.UtcNow;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // EDIT PRODUCT (GET)
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // EDIT PRODUCT (POST)
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.Find(product.Id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.UpdatedDate = DateTime.Now;
                existingProduct.Description = product.Description;
                

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // DELETE PRODUCT
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

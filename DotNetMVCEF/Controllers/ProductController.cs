using DotNetMVCEF.Models;
using DotNetMVCEF.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMVCEF.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProduct addProduct)
        {
            try
            {
                Product product = new Product()
                {
                    Name = addProduct.Name,
                    Description = addProduct.Description,
                    Price = addProduct.Price
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                var dbProduct = _context.Products.SingleOrDefault(p=>p.Id == product.Id);
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.Price = product.Price;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }       

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                var dbProduct = _context.Products.SingleOrDefault(p => p.Id == product.Id);
                _context.Products.Remove(dbProduct);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

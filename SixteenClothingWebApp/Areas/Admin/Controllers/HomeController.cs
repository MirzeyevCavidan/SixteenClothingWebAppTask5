using Microsoft.AspNetCore.Mvc;
using SixteenClothingWebApp.DAL;
using SixteenClothingWebApp.Models;

namespace SixteenClothingWebApp.Areas.Admin.Controllers
{

    [Area("admin")]
    
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Table");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }



        [HttpPost]
        
        
        
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Table");
        }

        public IActionResult Table()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Detail(int? id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]



        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "Image should be selected");
                return View(product);
            }

            if (!product.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Only image files are excepted");
                return View(product);
            }

            if (product.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Photo", "Image size should be maximum 2mb");
                return View(product);
            }

            string fileName = Guid.NewGuid() + "_" + product.Photo.FileName;
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/assets/images",
                fileName
            );

            using (FileStream stream = new(path, FileMode.Create))
            {
                await product.Photo.CopyToAsync(stream);
            }
            product.ImagePath = fileName;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Table));
        }
    }
}
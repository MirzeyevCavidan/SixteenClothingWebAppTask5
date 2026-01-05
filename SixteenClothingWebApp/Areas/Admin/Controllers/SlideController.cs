using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixteenClothingWebApp.DAL;
using SixteenClothingWebApp.Models;

namespace SixteenClothingWebApp.Areas.Admin.Controllers
{
    
    [Area("admin")]
    
    public class SlideController : Controller
    {
        
        public readonly AppDbContext _context;
        
        public SlideController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            List<Slide> slides = await _context.Sliders.ToListAsync();
            return View(slides);
        }

        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]



        public async Task<ActionResult> Create(Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return View(slide);
            }

            if (!slide.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Invalid file format");
                return View(slide);
            }

            if (slide.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Photo", "Invalid file format");
                return View(slide);
            }

            string fileName = String.Concat(Guid.NewGuid().ToString(), slide.Photo.FileName);
            string path = "C:\\Users\\Cavidan\\OneDrive\\Desktop\\SixteenClothingWebAppTask\\SixteenClothingWebApp\\wwwroot\\Admin\\images\\" + fileName;
            FileStream fileStream = new(path, FileMode.Create);

            await slide.Photo.CopyToAsync(fileStream);
            fileStream.Close();
            slide.Image = fileName;

            await _context.Sliders.AddAsync(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
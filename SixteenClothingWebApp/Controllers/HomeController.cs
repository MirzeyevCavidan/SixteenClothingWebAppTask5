using Microsoft.AspNetCore.Mvc;
using SixteenClothingWebApp.DAL;
using SixteenClothingWebApp.ViewModels;

namespace SixteenClothingWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Products = _context.Products.ToList()
            };
            return View(homeVM);
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
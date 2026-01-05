using Microsoft.AspNetCore.Mvc;

namespace SixteenClothingWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Top()
        {
            return View();
        }

        public IActionResult Left()
        {
            return View();
        }

        public IActionResult WelCome()
        {
            return View();
        }

        
    }
}
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //if (HttpContext.Session.GetInt32("userid") == null|| HttpContext.Session.GetInt32("userid")==0)
            //{
            //    return Content("<script>alert('Please Login This System');location.href='/Admin/Login'</script>","text/html");
            //}
            if (!User.Identity.IsAuthenticated)
                return Content("<script>alert('Please Login This System');location.href='/Admin/Login'</script>", "text/html");
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
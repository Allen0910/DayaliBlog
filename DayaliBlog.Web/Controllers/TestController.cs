using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DayaliBlog.Model.Blog;
using DayaliBlog.Service.Blog;
namespace DayaliBlog.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            BlogCategService service = new BlogCategService();
            var resBlogID= service.Insert(new T_BLOG_CATELOG { CatelogName="Python",CreateUser=1,UpdateUser=1});
            return Content("新增大类ID为："+resBlogID);
        }
        

        public IActionResult Error()
        {
            return View();
        }
    }
}

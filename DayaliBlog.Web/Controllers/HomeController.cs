using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Service.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;

namespace DayaliBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly BlogContentService _contentService = new BlogContentService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var list = _contentService.GetList("");
            return Json(list);
        }

        public IActionResult Detail(int id)
        {
            var model = _contentService.GetModel("b.BlogID=" + id);
            return View(model);
        }

        [HttpGet]
        public IActionResult CategLog()
        {
            int userid = HttpContext.Session.GetInt32("userid") == null
                ? 1
                : int.Parse(HttpContext.Session.GetInt32("userid").ToString());
            var list = _contentService.GetCategCount(userid);
            return Json(list);
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}

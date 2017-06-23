using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Service.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.Extensions.Options;
using DayaliBlog.Model.CustomModel;
using Microsoft.Extensions.Logging;

namespace DayaliBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly BlogContentService _contentService;
        readonly ILogger<HomeController> _logger;
        public HomeController(IOptions<MyOptions> options,ILogger<HomeController> logger)
        {
            _contentService = new BlogContentService(options.Value.DefaultConnection);
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var list = _contentService.GetList("");
            _logger.LogInformation("返回博客列表");
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
            var list = _contentService.GetCategCount(1);
            return Json(list);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

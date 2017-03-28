using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Model.Blog;
using DayaliBlog.Service.Blog;
using DayaliBlog.Service.Sys;
using Microsoft.AspNetCore.Mvc;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        BlogCategService _categService=new BlogCategService();
        BlogContentService _contentService=new BlogContentService();
        BlogCategRelService _relCateg=new BlogCategRelService();
        public IActionResult Index()
        {
            var list = _contentService.GetList("");
            return View(list);
        }

        public IActionResult Add(int? id)
        {
            ViewBag.BlogTypes = SysConfig.GetConfigList(SysConfig.BlogType);
            ViewBag.CategList = _categService.GetList("");
            T_BLOG_CONTENT content =new T_BLOG_CONTENT();
            if (id != null)
            {
                content = _contentService.GetModel(" b.BlogID=" + id.Value);
            }
            return View(content);
        }

        [HttpPost]
        public IActionResult Add(T_BLOG_CONTENT content)
        {
            int BlogID = 0;
            if (content.BlogID == 0)
            {
                content.CreateTIme = DateTime.Now;
                content.CreateUser = 1;
                content.LastUptTime = DateTime.Now;
                content.BlogState = 1;
                 BlogID= _contentService.Insert(content);
            }
            else
            {
                BlogID = content.BlogID;
                content.UpdateUser = 1;
                content.LastUptTime = DateTime.Now;
                content.BlogState = 1;
                bool isSuccess=_contentService.Update(content);
                if (isSuccess)
                    _relCateg.Delete(content.BlogID);
            }
            if (BlogID > 0)
                _relCateg.Insert(BlogID, content.CatelogID);
            return Redirect("/Admin/Blog/Index");
        }

        public IActionResult Del(int id)
        {
            _relCateg.Delete(id);
            _contentService.Delete(id);
            return Redirect("/Admin/Blog/Index");
        }
    }
}
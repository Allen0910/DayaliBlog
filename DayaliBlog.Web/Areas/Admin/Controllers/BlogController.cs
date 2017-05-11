using System;
using System.Collections;
using DayaliBlog.Model.Blog;
using DayaliBlog.Service.Blog;
using DayaliBlog.Service.Sys;
using Microsoft.AspNetCore.Mvc;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        readonly BlogCategService _categService = new BlogCategService();
        readonly BlogContentService _contentService = new BlogContentService();
        readonly BlogCategRelService _relCateg = new BlogCategRelService();

        public IActionResult GetTotalCount(string key, string start, string end, string categ)
        {
            string where = GetWhere(key, start, end, categ);
            int count = _contentService.GetCount(where);
            return Content(count.ToString());
        }

        public string GetWhere(string key, string start, string end, string categ)
        {
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(key))
            {
                where += $" and BlogContent like '%{key}%'";
            }
            if (!string.IsNullOrEmpty(start))
            {
                DateTime dtStart;
                if (DateTime.TryParse(start, out dtStart))
                    where += $" and CreateTIme>{dtStart:yyyy-MM-dd}";
            }
            if (!string.IsNullOrEmpty(end))
            {
                DateTime dtEnd;
                if (DateTime.TryParse(end, out dtEnd))
                {
                    where += $" and CreateTIme<{dtEnd:yyyy-MM-dd}";
                }
            }
            if (!string.IsNullOrEmpty(categ))
            {
                categ = Helper.GetSafeSQL(categ);
                where += $" and g.CatelogID={categ}";
            }
            return where;
        }

        public IActionResult GetListByPage(int pageIndex, int pageSize, string key, string start, string end, string categ)
        {
            var contion = GetWhere(key, start, end, categ);
            var list = _contentService.GetListByPage("", pageSize, pageIndex, contion);
            return Json(list);
        }

        public IActionResult Index()
        {
            ViewBag.CategList = _categService.GetList("");
            var list = _contentService.GetList("");
            return View(list);
        }


        public IActionResult Add(int? id)
        {
            ViewBag.BlogTypes = SysConfig.GetConfigList(SysConfig.BlogType);
            ViewBag.CategList = _categService.GetList("");
            T_BLOG_CONTENT content = new T_BLOG_CONTENT();
            if (id != null)
            {
                content = _contentService.GetModel(" b.BlogID=" + id.Value);
            }
            return View(content);
        }

        [HttpPost]
        public IActionResult Add(T_BLOG_CONTENT content)
        {
            int blogId = 0;
            if (content.BlogID == 0)
            {
                content.CreateTIme = DateTime.Now;
                content.CreateUser = 1;
                content.LastUptTime = DateTime.Now;
                content.BlogState = 1;
                blogId = _contentService.Insert(content);
            }
            else
            {
                blogId = content.BlogID;
                content.UpdateUser = 1;
                content.LastUptTime = DateTime.Now;
                content.BlogState = 1;
                bool isSuccess = _contentService.Update(content);
                if (isSuccess)
                    _relCateg.Delete(content.BlogID);
            }
            if (blogId > 0)
                _relCateg.Insert(blogId, content.CatelogID);
            return Redirect("/Admin/Blog/Index");
        }
        [HttpPost]
        public IActionResult Del(int id)
        {
            if (_relCateg.Delete(id) && _contentService.Delete(id))
                return Content("É¾³ý³É¹¦£¡");
            return Content("É¾³ýÊ§°Ü£¡");
        }
    }
}
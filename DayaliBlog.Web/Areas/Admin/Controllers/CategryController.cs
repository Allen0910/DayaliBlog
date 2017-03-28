using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Model.Blog;
using DayaliBlog.Service.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategryController : Controller
    {
        BlogCategService _categ=new BlogCategService();
        public IActionResult Index()
        {
            var list = _categ.GetList("");
            return View(list);
        }

        public IActionResult Add(int?id)
        {
            T_BLOG_CATELOG categ=new T_BLOG_CATELOG();
            if (id != null)
            {
                categ = _categ.GetList("CatelogID=" + id).First();
            }
            return View(categ);
        }

        [HttpPost]
        public IActionResult Add(T_BLOG_CATELOG model)
        {
            if (model.CatelogID == 0)
            {
                model.CreateUser = 1;
                model.CreateTime = DateTime.Now;
                _categ.Insert(model);
            }
            else
            {
                model.UpdateUser = 1;
                model.UpdateTime = DateTime.Now;
                _categ.Update(model);
            }
            return Redirect("/Admin/Categry/Index");
        }

        public IActionResult Del(int id)
        {
            _categ.Delete(id);
            return Redirect("/Admin/Categry/Index");
        }

    }
}
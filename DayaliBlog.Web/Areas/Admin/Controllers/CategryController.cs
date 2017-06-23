using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Model.Blog;
using DayaliBlog.Service.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DayaliBlog.Model.CustomModel;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategryController : Controller
    {
        BlogCategService _categ;
        public CategryController(IOptions<MyOptions> option)
        {
            _categ = new BlogCategService(option.Value.DefaultConnection) ;
        }
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
            int userId = HttpContext.Session.GetInt32("userid")==null?1:int.Parse(HttpContext.Session.GetInt32("userid").ToString());
            if (model.CatelogID == 0)
            {
                model.CreateUser = userId;
                model.CreateTime = DateTime.Now;
                _categ.Insert(model);
            }
            else
            {
                model.UpdateUser = userId;
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
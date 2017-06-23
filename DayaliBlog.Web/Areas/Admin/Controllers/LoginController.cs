using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Service.Sys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DayaliBlog.Model.CustomModel;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        SysUserService _userService;
        public LoginController(IOptions<MyOptions> option)
        {
            _userService = new SysUserService(option.Value.DefaultConnection);
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("userid",0);
            HttpContext.Session.SetString("username","");
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(string username,string password)
        {
            if(string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password))
            {
                return Content("empty");
            }
            password = Helper.MD5Hash(password);
            var listUsers= _userService.GetList(username, password);
            if (listUsers.Count > 0)
            {
                HttpContext.Session.SetInt32("userid", listUsers[0].UserID);
                HttpContext.Session.SetString("username", username);
                return Redirect("/Admin/Home");
            }
            return Content("error");
        }
    }
}
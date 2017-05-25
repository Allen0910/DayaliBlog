using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Service.Sys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string username,string password)
        {
            SysUserService userService=new SysUserService();
            password = Helper.MD5Hash(password);
            var listUsers=userService.GetList(username, password);
            if (listUsers.Count > 0)
            {
                HttpContext.Session.SetInt32("userid", listUsers[0].UserID);
                HttpContext.Session.SetString("username", username);
                return Redirect("/Admin/Home");
            }
            return Content("<script> alert('Login Error ! Username or Password Is Error !'); location.href='/Admin/Login'</script>", "text/html");
        }
    }
}
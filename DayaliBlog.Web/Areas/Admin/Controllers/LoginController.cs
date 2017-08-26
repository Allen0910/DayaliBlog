using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using DayaliBlog.Service.Sys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DayaliBlog.Model.CustomModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

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

        public async Task<IActionResult> Index()
        {
           // HttpContext.Session.SetInt32("userid", 0);
           // HttpContext.Session.SetString("username", "");

            #region 退出时删除Cookie
            if(User.Identity.IsAuthenticated)
            await HttpContext.SignOutAsync("MyCookieAuthenticationScheme");

            #endregion

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Content("empty");
            }
            password = Common.Security.MD5Security.MD5Hash(password);
            var listUsers = _userService.GetList(username, password);
            if (listUsers.Count > 0)
            {

                #region 登陆时创建身份Cookie

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid,listUsers[0].UserID.ToString()),
                    new Claim(ClaimTypes.Name,username)
                };

                ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "SuperSecureLogin"));
                await HttpContext.SignInAsync("MyCookieAuthenticationScheme", principal,new AuthenticationProperties()
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                #endregion

                //HttpContext.Session.SetInt32("userid", listUsers[0].UserID);
                //HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }
            return Content("error");
        }
    }
}
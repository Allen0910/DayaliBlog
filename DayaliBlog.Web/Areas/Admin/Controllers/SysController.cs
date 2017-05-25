using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayaliBlog.Model.Sys;
using DayaliBlog.Service.Sys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken()]
        [HttpPost]
        public IActionResult Index(string oldpassword,string newpwd1,string newpwd2)
        {
            if (HttpContext.Session.GetInt32("userid") == null)
            {
                return MsgContent("δ�ҵ����û�������ϵ����Ա!");
            }
            if (string.IsNullOrEmpty(oldpassword) || string.IsNullOrEmpty(newpwd1) || string.IsNullOrEmpty(newpwd2))
            {
                return MsgContent("����޸�������Ϣ��д����!");
            }

            if (newpwd1 != newpwd2)
            {
                return MsgContent("�����������벻��ͬ��");
            }

            SysUserService userService=new SysUserService();
            oldpassword = Helper.MD5Hash(oldpassword);
            int userid= int.Parse(HttpContext.Session.GetInt32("userid").ToString());
            string username = HttpContext.Session.GetString("username");
            var list = userService.GetList(username, oldpassword);
            if (list == null || list.Count <= 0)
                return MsgContent("ԭ�������");
            bool isSuccess = userService.Update(new T_SYS_USER() {UserID = userid, Password = Helper.MD5Hash(newpwd1)});
            if(isSuccess)
            return Content("<script>alert('�޸�����ɹ���');parent.location.href='/Admin/Login'</script>", "text/html");
            return MsgContent("�����޸�ʧ�ܣ�");
        }

        private IActionResult MsgContent(string message)
        {
            return Content("<script> alert(\'"+ message + "\');</script>\", \"text/html");
        }
    }
}
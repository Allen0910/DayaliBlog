using System;
using System.IO;
using DayaliBlog.Model.Blog;
using DayaliBlog.Service.Blog;
using DayaliBlog.Service.Sys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using DayaliBlog.Model.CustomModel;
using Microsoft.Extensions.Logging;

namespace DayaliBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        readonly BlogCategService _categService ;
        readonly BlogContentService _contentService;
        readonly BlogCategRelService _relCateg ;

        private readonly SysConfig _sysConfig;
        //���ڶ�ȡ��վ��̬�ļ�Ŀ¼
        private IHostingEnvironment hostingEnv;
        //���ڼ�¼��־
        private ILogger<BlogController> _logger;
        public BlogController(IHostingEnvironment env, IOptions<MyOptions> option, ILogger<BlogController> logger)
        {
            hostingEnv = env;
            _logger = logger;
            _categService = new BlogCategService(option.Value.DefaultConnection);
            _contentService = new BlogContentService(option.Value.DefaultConnection);
            _relCateg = new BlogCategRelService(option.Value.DefaultConnection);
            _sysConfig=new SysConfig(option.Value.DefaultConnection);
        }
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
            try
            {
                if (HttpContext.Session.GetInt32("userid") == null || HttpContext.Session.GetInt32("userid") == 0)
                {
                    return Content("<script>alert('Please Login This System��');location.href='/Admin/Login'</script>", "text/html");
                }
                var contion = GetWhere(key, start, end, categ);
                contion += " and b.CreateUser=" + HttpContext.Session.GetInt32("userid");
                var list = _contentService.GetListByPage("", pageSize, pageIndex, contion);
                return Json(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

            
        }

        public IActionResult Index()
        {
            ViewBag.CategList = _categService.GetList("");
            var list = _contentService.GetList("");
            return View(list);
        }


        public IActionResult Add(int? id)
        {
            ViewBag.BlogTypes = _sysConfig.GetConfigList(SysConfig.BlogType);
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
            try
            {
                //if (!ModelState.IsValid)
                //    return Content("<script> alert('���������������鲩�����ݣ�'); location.href='/Admin/Blog/Add'</script>", "text/html");
                int blogId = 0;
                int userId = HttpContext.Session.GetInt32("userid") == null
                    ? 1
                    : int.Parse(HttpContext.Session.GetInt32("userid").ToString());
                if (content.BlogID == 0)
                {
                    content.CreateTIme = DateTime.Now;
                    content.CreateUser = userId;
                    content.LastUptTime = DateTime.Now;
                    content.BlogState = 1;
                    blogId = _contentService.Insert(content);
                }
                else
                {
                    blogId = content.BlogID;
                    content.UpdateUser = userId;
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
           
        }
        [HttpPost]
        public IActionResult Del(int id)
        {
            if (_relCateg.Delete(id) && _contentService.Delete(id))
                return Content("ɾ���ɹ���");
            return Content("ɾ��ʧ�ܣ�");
        }
        /// <summary>
        /// layui�༭������ϴ�ͼƬ���� 
        //{
        //  "code": 0 //0��ʾ�ɹ�������ʧ��
        //  ,"msg": "" //��ʾ��Ϣ //һ���ϴ�ʧ�ܺ󷵻�
        //  ,"data": {
        //    "src": "ͼƬ·��"
        //    ,"title": "ͼƬ����" //��ѡ
        //  }
        //}
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ImgUpload()
        {
            try
            {
                var imgFile = Request.Form.Files[0];
                if (imgFile != null && !string.IsNullOrEmpty(imgFile.FileName))
                {
                    long size = 0;
                    string tempname = "";
                    var filename = ContentDispositionHeaderValue
                        .Parse(imgFile.ContentDisposition)
                        .FileName
                        .Trim('"');
                    var extname = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf(".")); //��չ������.jpg

                    #region �жϺ�׺
                    if (!extname.ToLower().Contains("jpg") && !extname.ToLower().Contains("png") && !extname.ToLower().Contains("gif"))
                    {
                        return Json(new { code = 1, msg = "ֻ�����ϴ�jpg,png,gif��ʽ��ͼƬ.", });
                    }
                    #endregion

                    #region �жϴ�С
                    long mb = imgFile.Length / 1024 / 1024; // MB
                    if (mb > 5)
                    {
                        return Json(new { code = 1, msg = "ֻ�����ϴ�С�� 5MB ��ͼƬ.", });
                    }
                    #endregion

                    var filename1 = System.Guid.NewGuid().ToString().Substring(0, 6) + extname;
                    tempname = filename1;
                    var path = hostingEnv.WebRootPath; //��վ��̬�ļ�Ŀ¼  wwwroot
                    string dir = DateTime.Now.ToString("yyyyMMdd");
                    //��������·��
                    string wuli_path = hostingEnv.WebRootPath + $"{Path.DirectorySeparatorChar}upload{Path.DirectorySeparatorChar}{dir}{Path.DirectorySeparatorChar}";
                    if (!System.IO.Directory.Exists(wuli_path))
                    {
                        System.IO.Directory.CreateDirectory(wuli_path);
                    }
                    filename = wuli_path + filename1;
                    size += imgFile.Length;
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        imgFile.CopyTo(fs);
                        fs.Flush();
                    }
                    return Json(new { code = 0, msg = "�ϴ��ɹ�", data = new { src = $"/upload/{dir}/{filename1}", title = filename1 } });
                }
                return Json(new { code = 1, msg = "�ϴ�ʧ��", });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DayaliBlog.Model.CustomModel;
using NLog.Extensions.Logging;
using Common.DomainRouter;

namespace DayaliBlog.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            //配置数据库连接串
            services.Configure<MyOptions>(Configuration.GetSection("ConnectionStrings"));
            // Add framework services.
            services.AddMvc();

            #region 弃用，改用IOption
            //取出appsetting.json中的数据库连接字符串
            //string connStr = Configuration.GetSection("ConnStr").Value;
            //services.AddSingleton<IConfiguration>(Configuration);
            //services.AddSingleton(new Service.Blog.BlogContentService() { ConnStr = connStr });
            //services.AddSingleton(new Service.Blog.BlogCategService() { ConnStr = connStr });
            //services.AddSingleton(new Service.Blog.BlogCategRelService() { ConnStr = connStr });
            //services.AddSingleton(new Service.Blog.BlogTagService() { ConnStr = connStr });
            //services.AddSingleton(new Service.Blog.BlogTagRelService(){ ConnStr = connStr });
            //services.AddSingleton(new Service.Sys.SysUserService(){ ConnStr = connStr });
            //services.AddSingleton(Service.Sys.SysConfig.ConnStr = connStr);
            #endregion

            //添加gb2312的支持
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                //网站域名,区域名,控制器名
                routes.MapDomainRoute("www.dayali.net", "Admin", "Login");

                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

# DayaliBlog
大鸭梨博客系统 17年3月14日修改并提交
17-03-14 21:40 添加了对Dapper的引用，Model层创建完成，并使用Dapper进行数据插入
17-03-26 17:00 添加必要的数据访问层代码
17-03-27 15:00 dotnetcore中区域创建以及添加后台页面
17-06-04 18:00 第一版本完成提交
17-06-03 17:00 解决错误，安装sqlserver for linux
17-06-04 18:50 更新数据库脚本 
17-06-05 15:00 配置数据库连接串由原来的注入方式改为使用IOptions接口(方便了在.NET Core应用程序中使用强类型配置,配置反序列化至配置类的实例中)
17-06-05 18:00 添加日志，使用NLog：
在.csproj中手动添加<PackageReference Include="NLog.Extensions.Logging" Version="1.0.0-rtm-alpha4" />，不知为何通过Nuget，找不到这个包，添加完后，手动添加nlog.config，然后在Configer中添加loggerFactory.AddNLog();，运行程序后会多出两个日志文件，nlog-all-*.log 是记录所有日志，nlog-own-*.log 记录跳过Microsoft 开头的类库输出的相关信息，剩下的信息。

17-06-23 15:00 添加404错误页

17-06-24 00:00 发布时Webconfig.config中不需要配置环境变量，出现500错误，出错原因为数据库连接串配置错误，修复字典业务类没有使用注入连接串的方式

17-06-24 22:00 修改默认页：
	routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
   前台首页和后台首页分别添加入口

17-06-25 21:00 新建Common类库，将工具类单独放到里面，日后有工具方法就会往里面添加

17-07-31 16:30 添加MySql.Data 类库，支持MySql数据库，mysql数据不支持dbo,将sql语句中得dbo.前缀去掉

17-08-23 14:00 项目升级到.net core 2.0

17-08-26 19:00 layui框架升级到v2.0.2,Upload控件，分页控件应用2.0写法

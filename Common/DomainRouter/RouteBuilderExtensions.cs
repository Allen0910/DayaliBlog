using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DomainRouter
{
    public static class RouteBuilderExtensions
    {
        public static IRouteBuilder MapDomainRoute(
           this IRouteBuilder routeBuilder, string domain, string area, string controller)
        {
            if (string.IsNullOrEmpty(area) || string.IsNullOrEmpty(controller))
            {
                throw new ArgumentNullException("area or controller can not be null");
            }
            var inlineConstraintResolver = routeBuilder
                .ServiceProvider
                .GetRequiredService<IInlineConstraintResolver>();

            string template = "";

            RouteValueDictionary defaults = new RouteValueDictionary();
            RouteValueDictionary constrains = new RouteValueDictionary();
            constrains.Add("area", area);
            defaults.Add("area", area);
            constrains.Add("controller", controller);
            defaults.Add("controller", string.IsNullOrEmpty(controller) ? "home" : controller);
            defaults.Add("action", "index");

            template += "{action}/{id?}";//路径规则中不再包含控制器信息，但是上面通过constrains限定了查找时所要求的控制器名称
            routeBuilder.Routes.Add(new SubDomainRouter(routeBuilder.DefaultHandler, domain, template, defaults, constrains, inlineConstraintResolver));


            return routeBuilder;
        }
    }
}

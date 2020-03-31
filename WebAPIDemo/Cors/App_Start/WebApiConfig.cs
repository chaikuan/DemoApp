using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cors
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            #region 跨域配置
            //1. 需要在可以跨域的控制器上增加 EnableCors 特性
            config.EnableCors();
            // 2.全部项目控制器可用
            var cors = new EnableCorsAttribute("www.example.com", "*", "*");
            config.EnableCors(cors);
            #endregion 跨域配置

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

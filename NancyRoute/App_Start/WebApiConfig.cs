using NancyRoute.Core;
using NancyRoute.Demo.Modules;
using System.Web.Http;

namespace NancyRoute.Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // NanycModules
            config.MapNancyModules(
                new HomeModule(),
                new TestModule()
            );

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
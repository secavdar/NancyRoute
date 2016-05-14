using NancyRoute.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NancyRoute.Core
{
    public abstract class NancyModule : NancyModuleBase
    {
        public NancyModule() { }

        public NancyModule(string controllerName)
        {
            _controllerName = controllerName;
        }

        private readonly string _controllerName;

        protected void Delete<T>(string routeTemplate, string actionName) where T : ApiController
        {
            Map<T>(routeTemplate, HttpMethod.Delete, actionName);
        }
        protected void Get<T>(string routeTemplate, string actionName) where T : ApiController
        {
            Map<T>(routeTemplate, HttpMethod.Get, actionName);
        }
        protected void Head<T>(string routeTemplate, string actionName) where T : ApiController
        {
            Map<T>(routeTemplate, HttpMethod.Head, actionName);
        }
        protected void Options<T>(string routeTemplate, string actionName) where T : ApiController
        {
            Map<T>(routeTemplate, HttpMethod.Options, actionName);
        }
        protected void Post<T>(string routeTemplate, string actionName) where T : ApiController
        {
            Map<T>(routeTemplate, HttpMethod.Post, actionName);
        }
        protected void Put<T>(string routeTemplate, string actionName) where T : ApiController
        {
            Map<T>(routeTemplate, HttpMethod.Put, actionName);
        }
        protected void Trace<T>(string routeTemplate, string actionName) where T : ApiController
        {
            Map<T>(routeTemplate, HttpMethod.Trace, actionName);
        }

        protected void Delete(string routeTemplate, string controllerName, string actionName)
        {
            Map(routeTemplate, HttpMethod.Delete, controllerName, actionName);
        }
        protected void Get(string routeTemplate, string controllerName, string actionName)
        {
            Map(routeTemplate, HttpMethod.Get, controllerName, actionName);
        }
        protected void Head(string routeTemplate, string controllerName, string actionName)
        {
            Map(routeTemplate, HttpMethod.Head, controllerName, actionName);
        }
        protected void Options(string routeTemplate, string controllerName, string actionName)
        {
            Map(routeTemplate, HttpMethod.Options, controllerName, actionName);
        }
        protected void Post(string routeTemplate, string controllerName, string actionName)
        {
            Map(routeTemplate, HttpMethod.Post, controllerName, actionName);
        }
        protected void Put(string routeTemplate, string controllerName, string actionName)
        {
            Map(routeTemplate, HttpMethod.Put, controllerName, actionName);
        }
        protected void Trace(string routeTemplate, string controllerName, string actionName)
        {
            Map(routeTemplate, HttpMethod.Trace, controllerName, actionName);
        }

        protected void Delete(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Delete, _controllerName, actionName);
        }
        protected void Get(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Get, _controllerName, actionName);
        }
        protected void Head(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Head, _controllerName, actionName);
        }
        protected void Options(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Options, _controllerName, actionName);
        }
        protected void Post(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Post, _controllerName, actionName);
        }
        protected void Put(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Put, _controllerName, actionName);
        }
        protected void Trace(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Trace, _controllerName, actionName);
        }

        protected virtual void Map<T>(string routeTemplate, HttpMethod method, string actionName)
        {
            string controllerName = typeof(T).Name.Replace("Controller", "");

            Map(routeTemplate, method, controllerName, actionName);
        }
    }

    public abstract class GenericNancyModule<T> : NancyModuleBase where T : ApiController
    {
        protected void Delete(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Delete, actionName);
        }
        protected void Get(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Get, actionName);
        }
        protected void Head(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Head, actionName);
        }
        protected void Options(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Options, actionName);
        }
        protected void Post(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Post, actionName);
        }
        protected void Put(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Put, actionName);
        }
        protected void Trace(string routeTemplate, string actionName)
        {
            Map(routeTemplate, HttpMethod.Trace, actionName);
        }

        protected virtual void Map(string routeTemplate, HttpMethod method, string actionName)
        {
            string controllerName = typeof(T).Name.Replace("Controller", "");

            Map(routeTemplate, method, controllerName, actionName);
        }
    }

    public abstract class NancyModuleBase
    {
        protected readonly List<INancyRoute> _routes;

        public NancyModuleBase()
        {
            var list = HttpContext.Current.Application["NancyRoutes"] as List<INancyRoute>;

            if (list == null)
                HttpContext.Current.Application["NancyRoutes"] = list = new List<INancyRoute>();

            _routes = list;
        }

        protected void Map(string routeTemplate, HttpMethod method, string controllerName, string actionName)
        {
            if (String.IsNullOrWhiteSpace(controllerName))
                throw new Exception("ControllerName must be defined!!!");

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: controllerName + "/" + actionName,
                routeTemplate: routeTemplate,
                defaults: new { controller = controllerName, action = actionName }
            );

            _routes.Add(new NancyRoute(routeTemplate, method, controllerName, actionName));
        }
    }
}
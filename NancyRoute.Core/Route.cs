using NancyRoute.Core.Contracts;
using System.Net.Http;

namespace NancyRoute.Core
{
    public class Route : IRoute
    {
        public Route(string routeTemplate, HttpMethod method, string controllerName, string actionName)
        {
            RouteTemplate = routeTemplate;
            Method = method;
            ControllerName = controllerName;
            ActionName = actionName;
        }

        public string RouteTemplate { get; set; }
        public HttpMethod Method { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
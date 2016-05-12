using NancyRoute.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace NancyRoute.Helpers
{
    public class RequestHandler : DelegatingHandler
    {
        private readonly List<Route> _routes = new List<Route>();

        public RequestHandler()
        {
            this._routes.Add(new Route("/Test1", HttpMethod.Get, "Home", "Test1"));
            this._routes.Add(new Route("/Test2", HttpMethod.Post, "Home", "Test2"));
            this._routes.Add(new Route("/Test3", HttpMethod.Put, "Home", "Test3"));
            //this._routes.Add(new Route("/Test4", HttpMethod.Delete, "Test", "Test"));

            this._routes.Add(Route.Register<TestController>("/Test4/deneme", HttpMethod.Delete, "Test"));
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var route = this._routes.FirstOrDefault(x => x.Path.Trim('/') == request.RequestUri.LocalPath.Trim('/') && x.Method == request.Method);

            if (route == null)
                return CreateErrorResponse(request, "Invalid Route!!");

            var routeData = request.GetRouteData();

            HttpRouteValueDictionary routes = new HttpRouteValueDictionary(routeData.Values);
            routes["action"] = route.ActionName;
            routes["controller"] = route.ControllerName;

            request.Method = HttpMethod.Post;
            request.SetRouteData(new HttpRouteData(routeData.Route, routes));

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> CreateErrorResponse(HttpRequestMessage request, string message)
        {
            HttpResponseMessage response = request.CreateErrorResponse(HttpStatusCode.Forbidden, message);
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
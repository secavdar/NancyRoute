using NancyRoute.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Routing;

namespace NancyRoute.Core
{
    public class NancyHandler : DelegatingHandler
    {
        private List<INancyRoute> Routes
        {
            get { return HttpContext.Current.Application["NancyRoutes"] as List<INancyRoute>; }
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (Routes == null)
                return CreateErrorResponse(request, "Invalid Route!!");

            var routeData = request.GetRouteData();

            var route = Routes.FirstOrDefault(x => x.RouteTemplate == routeData.Route.RouteTemplate && x.Method == request.Method);

            if (route == null)
                return CreateErrorResponse(request, "Invalid Route!!");

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
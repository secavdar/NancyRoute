using System.Net.Http;

namespace NancyRoute.Core.Contracts
{
    public interface INancyRoute
    {
        string ActionName { get; set; }
        string ControllerName { get; set; }
        HttpMethod Method { get; set; }
        string RouteTemplate { get; set; }
    }
}
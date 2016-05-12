using System.Net.Http;

namespace NancyRoute.Helpers
{
    public class Route
    {
        public Route() { }

        public Route(string path, HttpMethod method, string controllerName, string actionName)
        {
            Path = path;
            Method = method;
            ControllerName = controllerName;
            ActionName = actionName;
        }

        public static Route Register<T>(string path, HttpMethod method, string actionName)
        {
            return new Route(path, method, typeof(T).Name.Replace("Controller", ""), actionName);
        }

        public string Path { get; set; }
        public HttpMethod Method { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
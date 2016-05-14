using System.Web.Http;

namespace NancyRoute.Core
{
    public static class NancyHelper
    {
        public static void MapNancyModules(this HttpConfiguration config, params NancyModuleBase[] modules)
        {
            config.MessageHandlers.Add(new NancyHandler());
        }
    }
}
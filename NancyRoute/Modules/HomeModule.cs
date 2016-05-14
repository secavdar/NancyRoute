using NancyRoute.Core;
using NancyRoute.Demo.Controllers;

namespace NancyRoute.Demo.Modules
{
    public class HomeModule : GenericNancyModule<HomeController>
    {
        protected override void Register()
        {
            Get("Test/{categoryId}/A/{test}", "Test1");
            Post("Test/{categoryId}/A/{test}", "Test2");
        }
    }
}
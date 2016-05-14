using System.Web.Http;

namespace NancyRoute.Demo.Controllers
{
    public class HomeController : ApiController
    {
        public string Test1(string categoryId, string test)
        {
            return "Test1 / categoryId:" + categoryId + " / test:" + test;
        }

        public string Test2(string categoryId, string test)
        {
            return "Test2 / categoryId:" + categoryId + " / test:" + test;
        }

        public string Test3()
        {
            return "Test3";
        }
    }
}
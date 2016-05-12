using System.Web.Http;

namespace NancyRoute.Controllers
{
    public class HomeController : ApiController
    {
        public string Test1()
        {
            return "Test1";
        }

        public string Test2()
        {
            return "Test2";
        }

        public string Test3()
        {
            return "Test3";
        }
    }
}
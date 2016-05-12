using System.Web.Http;

namespace NancyRoute.Controllers
{
    public class TestController : ApiController
    {
        public string Test(string key)
        {
            return "Test / key: " + key;
        }
    }
}
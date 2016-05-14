using System;
using NancyRoute.Core;
using NancyRoute.Demo.Controllers;

namespace NancyRoute.Demo.Modules
{
    public class TestModule : GenericNancyModule<TestController>
    {
        protected override void Register()
        {
            //throw new NotImplementedException();
        }
    }
}
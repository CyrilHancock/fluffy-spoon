using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace codecrafters_http_server.src
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MyRouteAttribute : Attribute
    {
        public string Route { get; }

        public MyRouteAttribute(string route)
        {
            Route = route;
        }
    }
  public class HttpGet : Attribute
    {
        public HttpGet() { }
    }

    public class HttpPost : Attribute
    {
        public HttpPost() { }
    }



}

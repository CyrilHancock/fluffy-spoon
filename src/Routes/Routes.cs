using codecrafters_http_server.src.DTOS;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace codecrafters_http_server.src.Routes
{
    public  class MyRoutes
    {
        [MyRoute("/hello")]
        [HttpPost]
        public static JObject HelloRoute(JObject context)
        {
            ///Any type of manimulatation
            return context;
        }

        [MyRoute("/goodbye")]
        public static void GoodbyeRoute(HttpResponseDto context)
        {
            Console.WriteLine("GoodByeeee");
        }
    }
}


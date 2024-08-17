using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codecrafters_http_server.src.DTOS
{
   
        public static class HttpResponseConstants
        {
        // 200 OK Response
        public static readonly HttpResponseDto OkResponse = new HttpResponseDto
        {
            StatusLine = "HTTP/1.1 200 OK\r\n",
            Headers = "Server: Crude Server\r\nContent-Type: text/html\r\n",
            BlankLine = "\r\n",

            ResponseBody = @"{ ""id"": 123, ""name"": ""John Doe"", ""email"": ""john@example.com"" }" // Additional data in JSON format
            };


        // 404 Not Found Response
        public static readonly HttpResponseDto NotFoundResponse = new HttpResponseDto
            {
                StatusLine = "HTTP/1.1 404 Not Found\r\n",
                Headers = "Server: Crude Server\r\nContent-Type: text/html\r\n",
                BlankLine = "\r\n",
                ResponseBody = @"<html>
                            <body>
                                <h1>Page not found!</h1>
                            </body>
                         </html>"
            };

            // 405 Method Not Allowed Response
            public static readonly HttpResponseDto MethodNotAllowedResponse = new HttpResponseDto
            {
                StatusLine = "HTTP/1.1 405 Method Not Allowed\r\n",
                Headers = "Server: Crude Server\r\nContent-Type: text/html\r\n",
                BlankLine = "\r\n",
                ResponseBody = @"<html>
                            <body>
                                <h1>Method not allowed!</h1>
                            </body>
                         </html>"
            };

            // 400 Bad Request Response
            public static readonly HttpResponseDto BadRequestResponse = new HttpResponseDto
            {
                StatusLine = "HTTP/1.1 400 Bad Request\r\n",
                Headers = "Server: Crude Server\r\nContent-Type: text/html\r\n",
                BlankLine = "\r\n",
                ResponseBody = @"<html>
                            <body>
                                <h1>Bad request!</h1>
                            </body>
                         </html>"
            };

            // 204 No Content Response
            public static readonly HttpResponseDto NoContentResponse = new HttpResponseDto
            {
                StatusLine = "HTTP/1.1 204 No Content\r\n",
                Headers = "Server: Crude Server\r\nContent-Type: text/html\r\n",
                BlankLine = "\r\n",
                ResponseBody = string.Empty // No content
            };

            // 301 Moved Permanently Response
            public static readonly HttpResponseDto MovedPermanentlyResponse = new HttpResponseDto
            {
                StatusLine = "HTTP/1.1 301 Moved Permanently\r\n",
                Headers = "Server: Crude Server\r\nLocation: https://newurl.com/\r\n",
                BlankLine = "\r\n",
                ResponseBody = @"<html>
                            <body>
                                <h1>Moved Permanently!</h1>
                            </body>
                         </html>"
            };

            // 304 Not Modified Response
            public static readonly HttpResponseDto NotModifiedResponse = new HttpResponseDto
            {
                StatusLine = "HTTP/1.1 304 Not Modified\r\n",
                Headers = "Server: Crude Server\r\n",
                BlankLine = "\r\n",
                ResponseBody = string.Empty // No content for 304
            };
        }
      
        public class HttpResponseDto
        {
            public string StatusLine { get; set; }
            public string Headers { get; set; }
            public string BlankLine { get; set; }
            public string ResponseBody { get; set; }
        public static string  HttpResponseString(dynamic httpResponse)
        {
            return httpResponse.StatusLine + httpResponse.Headers + httpResponse.BlankLine + httpResponse.ResponseBody ;
        }
        public class HttpRequestDto
        {
            public string Method { get; set; }
            public string Path { get; set; }
            public string HttpVersion { get; set; }
            public Dictionary<string, string> Headers { get; set; }
            public string Body { get; set; }
            public JObject JsonBody { get; set; } 
            public HttpRequestDto()
            {
                Headers = new Dictionary<string, string>();
            }
        }


    }

}

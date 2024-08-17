using codecrafters_http_server.src.DTOS;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static codecrafters_http_server.src.DTOS.HttpResponseDto;

namespace codecrafters_http_server.src.Requests
{
    internal class Requests
    {
        public string HandleRequests(string data)
        {
            HttpRequestDto requestDto=new HttpRequestDto();
            HttpResponseDto responseDto=new HttpResponseDto();
            try
            {
                 requestDto = ParseHttpRequest(data);

            }
            catch (Exception)
            {
                responseDto = HttpResponseConstants.BadRequestResponse;
                return HttpResponseString(responseDto);
            }

            MethodInfo matchedMethod = FindRoute(requestDto.Path,requestDto.Method);
            try
            {
                if (matchedMethod != null)
                {
                    if(matchedMethod.Invoke(null, new JObject[] { requestDto.JsonBody }) == null)
                    {
                        responseDto = HttpResponseConstants.NoContentResponse;
                    }
                    else
                    {
                    responseDto = HttpResponseConstants.OkResponse;
                    responseDto.ResponseBody = matchedMethod.Invoke(null, new object[] { requestDto.JsonBody }).ToString();
                    }
                }
                else
                {
                 responseDto = HttpResponseConstants.NotFoundResponse;
                }

                return HttpResponseString(responseDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception();
            }
            
        }


        private MethodInfo FindRoute(string path, string requestType)
        {
            // Search through all methods in this assembly for the custom route attribute
            foreach (var method in Assembly.GetExecutingAssembly().GetTypes()
                                           .SelectMany(t => t.GetMethods())
                                           .Where(m => m.GetCustomAttributes(typeof(MyRouteAttribute), false).Length > 0))
            {
                var attr = (MyRouteAttribute)method.GetCustomAttribute(typeof(MyRouteAttribute));

                // Check if the route matches
                if (attr.Route.Equals(path, StringComparison.OrdinalIgnoreCase))
                {
                    // Check for the corresponding HTTP method attribute
                    if ((requestType.Equals("GET", StringComparison.OrdinalIgnoreCase) && method.GetCustomAttribute(typeof(HttpGet)) != null) ||
                        (requestType.Equals("POST", StringComparison.OrdinalIgnoreCase) && method.GetCustomAttribute(typeof(HttpPost)) != null))
                    {
                        return method;
                    }
                }
            }
            return null;
        }
        public static HttpRequestDto ParseHttpRequest(string httpRequest)
        {
            var dto = new HttpRequestDto();

            // Split the request into lines
            string[] lines = httpRequest.Split(new[] { "\r\n" }, StringSplitOptions.None);

            // Parse the request line
            string[] requestLine = lines[0].Split(' ');
            dto.Method = requestLine[0];
            dto.Path = requestLine[1];
            dto.HttpVersion = requestLine[2];

            // Parse the headers
            int lineIndex = 1;
            while (!string.IsNullOrWhiteSpace(lines[lineIndex]))
            {
                string[] headerParts = lines[lineIndex].Split(new[] { ": " }, 2, StringSplitOptions.None);
                dto.Headers[headerParts[0]] = headerParts[1];
                lineIndex++;
            }

            // The body starts after the empty line, so increment lineIndex
            lineIndex++;

            // Parse the body (if present)
            if (lineIndex < lines.Length)
            {
                dto.Body = string.Join("\r\n", lines, lineIndex, lines.Length - lineIndex);

                // Convert the body to a JObject if it's a valid JSON
                try
                {
                    dto.JsonBody = JObject.Parse(dto.Body);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }

            return dto;
        }
    }
}

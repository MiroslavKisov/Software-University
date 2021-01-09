namespace SIS.HTTP.Extensions
{
    using Enums;
    using System;

    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode statusCode)
        {
            string responseCode = null;

            switch (statusCode)
            {
                case HttpResponseStatusCode.Ok:
                    responseCode = "200 OK";
                    break;
                case HttpResponseStatusCode.Created:
                    responseCode = "201 Created";
                    break;
                case HttpResponseStatusCode.Found:
                    responseCode = "302 Found";
                    break;
                case HttpResponseStatusCode.SeeOther:
                    responseCode = "303 See Other";
                    break;
                case HttpResponseStatusCode.BadRequest:
                    responseCode = "400 Bad Request";
                    break;
                case HttpResponseStatusCode.Unauthorized:
                    responseCode = "401 Unauthorized";
                    break;
                case HttpResponseStatusCode.Forbidden:
                    responseCode = "403 Forbidden";
                    break;
                case HttpResponseStatusCode.NotFound:
                    responseCode = "404 Not Found";
                    break;
                case HttpResponseStatusCode.InternalServerError:
                    responseCode = "500 Internal Server Error";
                    break;
                default:
                    throw new ArgumentNullException("Response code cannot be null");
            }

            return responseCode;
        }
    }
}

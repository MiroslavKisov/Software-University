namespace SIS.Demo
{
    using WebServer.Results;
    using HTTP.Enums;
    using HTTP.Responses.Contracts;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello, World</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}

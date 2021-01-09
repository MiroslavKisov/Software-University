namespace Cake.App.Controllers
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
           return this.View("index");
        }

        public IHttpResponse HelloUser(IHttpRequest httpRequest)
        {
            return new HtmlResult($"<h1>Hello {this.GetUserName(httpRequest)}</h1>", HttpResponseStatusCode.Ok);
        }
    }
}

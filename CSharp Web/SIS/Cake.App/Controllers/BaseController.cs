namespace Cake.App.Controllers
{
    using Data;
    using Services;
    using Services.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System.IO;

    public abstract class BaseController
    {

        public BaseController()
        {
            this.UserCookieService = new UserCookieService();
            this.Db = new CakeContext();
        }

        protected IUserCookieService UserCookieService { get; }

        protected CakeContext Db { get; set; }

        protected string GetUserName(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return null;
            }

            var cookie = request.Cookies.GetCookie(".auth-cakes");
            var cookieContent = cookie.Value;
            var userName = this.UserCookieService.GetUserData(cookieContent);
            return userName;
        }

        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText("Views/" + viewName + ".html");
            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.BadRequest);
        }

        protected IHttpResponse ServerError(string errorMessage)
        {
            return new HtmlResult($"<h1>{errorMessage}</h1>", HttpResponseStatusCode.InternalServerError);
        }
    }
}

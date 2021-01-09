namespace IRunes.App.Controllers
{
    using Data;
    using Constants;
    using Services;
    using Services.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System.IO;

    public abstract class BaseController
    {
        protected BaseController()
        {
            this.Db = new IRunesContext();
            this.UserCookieService = new UserCookieService();
        }

        protected IRunesContext Db { get; set; }

        protected IUserCookieService UserCookieService { get; set; }

        protected string GetUserName(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(AppConstants.AuthIRunes))
            {
                return null;
            }

            var cookie = request.Cookies.GetCookie(AppConstants.AuthIRunes);
            var cookieContent = cookie.Value;
            var userName = this.UserCookieService.GetUserData(cookieContent);
            return userName;
        }

        protected IHttpResponse View(string viewName, string viewTemplate)
        {
            var template = File.ReadAllText(viewTemplate);
            var content = File.ReadAllText(viewName);
            var fullView = template.Replace(AppConstants.RenderBody, content);
            return new HtmlResult(fullView, HttpResponseStatusCode.Ok);
        }

        protected IHttpResponse View(string viewName, string viewTemplate, string variableForReplacing)
        {
            var viewContent = File.ReadAllText(viewName);
            var fullViewContent = viewContent.Replace(AppConstants.Variable, variableForReplacing);
            var template = File.ReadAllText(viewTemplate);
            var fullView = template.Replace(AppConstants.RenderBody, fullViewContent);
            return new HtmlResult(fullView, HttpResponseStatusCode.Ok);
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

namespace IRunes.App.Controllers
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using Constants;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            return this.View(AppConstants.IndexPath, AppConstants.ViewTemplatePath);
        }
    }
}

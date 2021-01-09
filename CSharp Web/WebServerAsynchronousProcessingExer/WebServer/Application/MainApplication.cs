namespace WebServer.Application
{
    using Server.Contracts;
    using Server.Routing.Contracts;
    using Server.Handlers;
    using Controllers;

    public class MainApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            //appRouteConfig.AddRoute("/", new GetHandler(request => new HomeController().Index()));

            appRouteConfig.Get("/", request => new HomeController().Index());
        }
    }
}

namespace IRunes.App
{
    using Constants;
    using Models;
    using Controllers;
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Routing;

    public class StartUp
    {
        public static void Main()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.HomeIndexRoute] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.IndexRoute] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.IndexSlashRoute] = request => new HomeController().Index(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.UsersRegisterRoute] = request => new AccountController().Register(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.UsersLoginRoute] = request => new AccountController().Login(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post][AppConstants.UsersRegisterRoute] = request => new AccountController().RegisterUser(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post][AppConstants.UsersLoginRoute] = request => new AccountController().LoginUser(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.AllAlbumsRoute] = request => new AlbumController().AlbumsView(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.CreateAlbumsRoute] = request => new AlbumController().CreateAlbumsView(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post][AppConstants.AlbumSuccessRoute] = request => new AlbumController().CreateAlbum(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.AlbumSuccessRoute] = request => new AlbumController().AlbumDetailsView(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.AlbumsDetailsRoute] = request => new AlbumController().AlbumDetailsView(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.CreateTrackRoute] = request => new TrackController().CreateTrackView(request);
            serverRoutingTable.Routes[HttpRequestMethod.Post][AppConstants.CreateTrackRoute] = request => new TrackController().CreateTrack(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.TrackDetailsRoute] = request => new TrackController().TrackDetailsView(request);
            serverRoutingTable.Routes[HttpRequestMethod.Get][AppConstants.AlbumDetailsRoute] = request => new AlbumController().AlbumDetailsView(request);

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}

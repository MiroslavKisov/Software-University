namespace SIS.Demo
{
    using WebServer.Routing;
    using HTTP.Enums;
    using WebServer;
    using SIS.HTTP.Requests;
    using System;

    public class Launcher
    {
        public static void Main()
        { 
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}

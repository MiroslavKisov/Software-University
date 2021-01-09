namespace WebServer.Server.Exceptions
{
    using System;

    public class InvalidRouteParameter : Exception
    {
        public InvalidRouteParameter(string message, string str)
           :base(message)
        {
        }
    }
}

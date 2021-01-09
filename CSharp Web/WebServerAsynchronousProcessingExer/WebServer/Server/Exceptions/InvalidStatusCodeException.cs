namespace WebServer.Server.Exceptions
{
    using System;

    public class InvalidStatusCodeException : Exception
    {
        public InvalidStatusCodeException(string message) : base(message)
        {
        }
    }
}

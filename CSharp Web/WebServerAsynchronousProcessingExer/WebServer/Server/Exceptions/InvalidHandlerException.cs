namespace WebServer.Server.Exceptions
{
    using System;

    public class InvalidHandlerException : Exception
    {
        public InvalidHandlerException(string message)
            : base(message)
        {
        }
    }
}

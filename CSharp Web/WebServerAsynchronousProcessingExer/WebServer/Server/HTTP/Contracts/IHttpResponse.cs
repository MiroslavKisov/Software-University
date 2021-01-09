namespace WebServer.Server.HTTP.Contracts
{
    using Enums;

    public interface IHttpResponse
    {
        HttpHeaderCollection Headers { get; }

        HttpStatusCode StatusCode { get; }
    }
}

namespace SIS.HTTP.Responses.Contracts
{
    using Enums;
    using Headers.Contracts;
    using Headers;
    using Cookies;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        void AddCookie(HttpCookie cookie);

        byte[] GetBytes();
    }
}

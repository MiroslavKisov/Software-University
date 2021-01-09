namespace SIS.HTTP.Requests.Contracts
{
    using Headers.Contracts;
    using Enums;
    using System.Collections.Generic;
    using Cookies.Contracts;
    using Sessions.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        IHttpSession Session { get; set; }

        IHttpCookieCollection Cookies { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }
    }
}

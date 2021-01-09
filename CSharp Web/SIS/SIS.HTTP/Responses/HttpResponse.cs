namespace SIS.HTTP.Responses
{
    using Contracts;
    using Common;
    using Enums;
    using Headers;
    using Extensions;
    using Headers.Contracts;
    using System;
    using System.Text;
    using System.Linq;
    using Cookies.Contracts;
    using Cookies;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {

        }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Cookies = new HttpCookieCollection();
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public IHttpCookieCollection Cookies { get; }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            CommonValidator.ValidateObject(header, nameof(header));
        }

        public byte[] GetBytes()
        {
            var toStringBytes = Encoding.UTF8.GetBytes(ToString());

            return toStringBytes.Concat(this.Content).ToArray();
        }

        public void AddCookie(HttpCookie cookie)
        {
            CommonValidator.ValidateObject(cookie, nameof(cookie));
            this.Cookies.Add(cookie);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstans.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .Append(Environment.NewLine)
                .Append(this.Headers)
                .Append(Environment.NewLine);

            if (this.Cookies.HasCookies())
            {
                result.Append($"Set-Cookie: {this.Cookies}").Append(Environment.NewLine);
            }

            result.Append(Environment.NewLine);

            return result.ToString();
        }
    }
}

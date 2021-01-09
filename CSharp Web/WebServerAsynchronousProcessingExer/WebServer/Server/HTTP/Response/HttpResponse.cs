namespace WebServer.Server.HTTP.Response
{
    using Enums;
    using System.Text;
    using Contracts;

    public abstract class HttpResponse : IHttpResponse
    {
        private string StatusCodeMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }

        public HttpHeaderCollection Headers { get; }

        public HttpStatusCode StatusCode { get; protected set; }

        public override string ToString()
        {
            var response = new StringBuilder();
            var statusCode = (int)this.StatusCode;

            response.AppendLine($"HTTP/1.1 {statusCode} {this.StatusCodeMessage}");

            response.AppendLine(this.Headers.ToString());
            response.AppendLine();

            return response.ToString();
        }
    }
}

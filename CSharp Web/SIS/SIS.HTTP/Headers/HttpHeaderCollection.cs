namespace SIS.HTTP.Headers
{
    using Contracts;
    using Common;
    using System.Collections.Generic;
    using System.Text;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            CommonValidator.ValidateObject(header, nameof(header));

            this.headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            CommonValidator.ValidateString(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CommonValidator.ValidateString(key, nameof(key));

            return this.headers[key];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var header in this.headers.Values)
            {
                sb.AppendLine(header.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

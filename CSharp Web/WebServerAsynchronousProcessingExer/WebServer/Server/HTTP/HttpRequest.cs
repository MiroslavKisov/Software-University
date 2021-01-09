namespace WebServer.Server.HTTP
{
    using System.Collections.Generic;
    using Enums;
    using Contracts;
    using Common;
    using System;
    using System.Linq;
    using Exceptions;
    using System.Net;
    //?
    public class HttpRequest : IHttpRequest
    {
        private const string HttpProtocol = "http/1.1";
        private const string InvalidRequest = "Request is not valid!";

        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public IDictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            var requestLines = requestString.Split(Environment.NewLine);

            if (!requestLines.Any())
            {
                throw new BadRequestException(InvalidRequest);
            }


            var requestLine = requestLines.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != HttpProtocol)
            {
                throw new BadRequestException(InvalidRequest);
            }

            this.Method = this.ParseMedhod(requestLine.First());
            this.Url = requestLine[1];
            this.Path = this.ParsePath(this.Url);
            this.ParseHeaders(requestLines);
            this.ParseParameters();
            this.ParseFormData(requestLines.Last()); 
        }

        private void ParseFormData(string requestLine)
        {
            if (this.Method == HttpRequestMethod.Post)
            {
                //? 
                this.ParseQuery(requestLine, this.FormData);
            }
        }
        
        private void ParseParameters()
        {
            if (this.Url.Contains('?'))
            {
                return;
            }

            string query = this.Url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries).Last();
            //?
            this.ParseQuery(query, this.QueryParameters);
        }
        //?
        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if (!query.Contains('='))
            {
                return;
            }

            var queryPairs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var queryPair in queryPairs)
            {
                var queryKvp = queryPair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (queryKvp.Length != 2)
                {
                    continue;
                }

                var queryKey = WebUtility.UrlDecode(queryKvp[0]);
                var queryValue = WebUtility.UrlDecode(queryKvp[1]);

                dict.Add(queryKey, queryValue);
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            var lastIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < lastIndex; i++)
            {
                var currentLine = requestLines[i];
                var headerArgs = currentLine.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (headerArgs.Length != 2)
                {
                    throw new BadRequestException(InvalidRequest);
                }

                var headerKey = headerArgs[0];
                var headerValue = headerArgs[1].Trim();

                this.Headers.Add(new HttpHeader(headerKey, headerValue));
            }

            if (!this.Headers.ContainsKey("Host"))
            {
                throw new BadRequestException(InvalidRequest);
            }
        }

        private string ParsePath(string url)
        {
            return url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries).First();
        }

        private HttpRequestMethod ParseMedhod(string method)
        {
            try
            {
                return Enum.Parse<HttpRequestMethod>(method, true);
            }
            catch (Exception)
            {
                throw new BadRequestException(InvalidRequest);
            }
        }
    }
}

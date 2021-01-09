namespace SIS.HTTP.Requests
{
    using Enums;
    using Headers.Contracts;
    using Requests.Contracts;
    using Headers;
    using System.Collections.Generic;
    using System;
    using Common;
    using Exceptions;
    using System.Linq;
    using Extensions;
    using Cookies.Contracts;
    using Cookies;
    using Sessions.Contracts;
    using Sessions;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CommonValidator.ValidateString(requestString, nameof(requestString));
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.Session = new HttpSession();
            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpSession Session { get; set; }

        public IHttpCookieCollection Cookies { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();
            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 && requestLine[2] == GlobalConstans.HttpOneProtocolFragment;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return !string.IsNullOrEmpty(queryString) && queryParameters.Length >= 1;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var requestMethod = requestLine[0].Capitalize();

            this.RequestMethod = Enum.Parse<HttpRequestMethod>(requestMethod, true);
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split(new string[] { "?", "#" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        }

        private void ParseHeaders(string[] requestContent)
        {
            var headers = requestContent.Where(e => e != "").ToArray();

            if (this.RequestMethod == HttpRequestMethod.Get)
            {
                AddHeaders(headers);
            }
            else if (this.RequestMethod == HttpRequestMethod.Post)
            {
                var formData = headers[headers.Length - 1];
                headers = headers.Take(headers.Length - 1).ToArray();
                AddHeaders(headers);
                ParseFormDataParameters(formData);
            }
        }

        private void ParseQueryParameters()
        {
            var urlArgs = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries);

            if (urlArgs.Length < 2)
            {
                return;
            }

            var query = urlArgs[1];
            if (query == null)
            {
                return;
            }

            var queryArgs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (!IsValidRequestQueryString(query, queryArgs))
            {
                throw new BadRequestException();
            }

            foreach (var q in queryArgs)
            {
                var queryInfo = q.Split('=');

                if (queryInfo.Length != 2)
                {
                    continue;
                }

                var queryKey = queryInfo[0];
                var queryValue = queryInfo[1];

                this.QueryData[queryKey] = queryValue;
            }
        }
        //Needs testing
        private void ParseFormDataParameters(string formData)
        {
            var formDataArgs = formData.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (formDataArgs.Length == 0)
            {
                return;
            }

            foreach (var f in formDataArgs)
            {
                var formInfo = f.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (formInfo.Length != 2)
                {
                    continue;
                }

                var formKey = formInfo[0];
                var formValue = formInfo[1];
                this.FormData[formKey] = formValue;
            }
        }

        private void ParseRequestParameters(string formData)
        {
            ParseFormDataParameters(formData);
            ParseQueryParameters();
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(GlobalConstans.CookieHeader))
            {
                HttpHeader cookieHeader = this.Headers.GetHeader(GlobalConstans.CookieHeader);

                var cookieArgs = cookieHeader.Value.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var c in cookieArgs)
                {
                    var cookieInfo = c.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);

                    var cookieName = cookieInfo[0].Trim();
                    var cookieValue = cookieInfo[1].Trim();

                    var cookie = new HttpCookie(cookieName, cookieValue);

                    this.Cookies.Add(cookie);
                }
            }
        }

        private void AddHeaders(string[] headers)
        {
            foreach (var h in headers)
            {
                var headerArgs = h.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                var header = new HttpHeader(headerArgs[0], headerArgs[1]);

                this.Headers.Add(header);
            }
        }
    }
}

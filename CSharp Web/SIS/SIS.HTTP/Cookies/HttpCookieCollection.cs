namespace SIS.HTTP.Cookies
{
    using Cookies.Contracts;
    using System.Collections.Generic;
    using Common;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            CommonValidator.ValidateObject(cookie, nameof(cookie));
            this.cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            CommonValidator.ValidateString(key, nameof(key));
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            CommonValidator.ValidateString(key, nameof(key));
            return this.cookies[key];
        }

        public bool HasCookies()
        {
            return this.cookies.Any();
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}

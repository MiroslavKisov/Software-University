namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enums;
    using Handlers;
    using Exceptions;
    using HTTP.Contracts;

    public class AppRouteConfig : IAppRouteConfig
    {
        private const string InvalidHandler = "Invalid handler.";

        private readonly Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>>();

            var availableMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes => this.routes;

        public void Get(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, new GetHandler(handler));
        }

        public void Post(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, new PostHandler(handler));
        }

        public void AddRoute(string route, RequestHandler handler)
        {
            if (handler.GetType().ToString().ToLower().Contains("get"))
            {
                this.routes[HttpRequestMethod.Get].Add(route, handler);
            }
            else if (handler.GetType().ToString().ToLower().Contains("post"))
            {
                this.routes[HttpRequestMethod.Post].Add(route, handler);
            }
            else
            {
                throw new InvalidHandlerException(InvalidHandler);
            }
        }
    }
}

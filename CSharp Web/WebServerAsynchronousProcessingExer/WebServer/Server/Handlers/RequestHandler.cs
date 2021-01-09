namespace WebServer.Server.Handlers
{
    using Common;
    using System;
    using Contracts;
    using HTTP.Contracts;
    using HTTP;

    public abstract class RequestHandler : IRequestHandler
    {
        private const string ContentType = "Content-Type";
        private const string TextType = "text/plain";

        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));

            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            var response = this.handlingFunc(context.Request);

            response.Headers.Add(new HttpHeader(ContentType, TextType));

            return response; 
        }
    }
}

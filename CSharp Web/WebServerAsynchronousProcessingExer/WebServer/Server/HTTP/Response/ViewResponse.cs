namespace WebServer.Server.HTTP.Response
{
    using Server.Contracts;
    using Enums;
    using Exceptions;

    public class ViewResponse : HttpResponse
    {
        private const string StatusCodeExceptionMsg = "Invalid status code.Code must not be between 300 and 399";

        private readonly IView view;

        //?
        public ViewResponse(HttpStatusCode statusCode, IView view)
        {
            this.ValidateStatusCode(statusCode);

            this.view = view;
            this.StatusCode = statusCode;
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if (statusCodeNumber > 299 && statusCodeNumber < 400)
            {
                throw new InvalidStatusCodeException(StatusCodeExceptionMsg);
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }
    }
}

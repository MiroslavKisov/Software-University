namespace WebServer.Server.HTTP.Response
{
    using Common;
    using Enums;

    public class RedirectResponse : HttpResponse
    {
        private const string Location = "Location";

        public RedirectResponse(string redirectUrl)
        {
            //?
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;
            this.Headers.Add(new HttpHeader(Location, redirectUrl));
        }
    }
}

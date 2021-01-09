namespace SIS.WebServer.Results
{
    using HTTP.Responses;
    using HTTP.Enums;
    using System.Text;
    using HTTP.Headers;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/plain"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}

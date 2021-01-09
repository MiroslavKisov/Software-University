namespace ValidateURL
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    public class Engine
    {
        private static string invalidUrl = "Invalid URL";
        private static string http = "http";
        private static string https = "https";
        private static string httpPort = "80";
        private static string httpsPort = "443";

        public void Run()
        {
            string pattern = @"(https{0,1}):\/\/([A-Za-z0-9\-\.]+\.[a-zA-Z0-9]+):?([0-9]+)?(\/[A-Za-z0-9\/]+\.?[a-z]+)?\?{0,1}([\=\&A-Za-z0-9]+[A-Za-z0-9]+\&?){0,20}\#{0,1}([A-Za-z0-9]+)?";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            string url = WebUtility.UrlDecode(input);

            Match match = regex.Match(url);

            if (match.Success)
            {
                string protocol = match.Groups[1].Value;
                string host = match.Groups[2].Value;
                string port = match.Groups[3].Value;
                string path = match.Groups[4].Value;
                string query = match.Groups[5].Value;
                string fragment = match.Groups[6].Value;

                if (protocol == http && port == httpsPort)
                {
                    Console.WriteLine(invalidUrl);
                    return;
                }
                else if (protocol == https && port == httpPort)
                {
                    Console.WriteLine(invalidUrl);
                    return;
                }

                if (port == "" && protocol == http)
                {
                    port = "80";
                }

                if (port == "" && protocol == https)
                {
                    port = "443";
                }

                if (path == "")
                {
                    path = "\\";
                }

                Console.WriteLine($"Protocol: {protocol}");
                Console.WriteLine($"Host: {host}");
                Console.WriteLine($"Port: {port}");
                Console.WriteLine($"Path: {path}");

                if (query == "" && fragment != "")
                {
                    Console.WriteLine($"Fragment: {fragment}");
                }
                else if (query != "" && fragment == "")
                {
                    Console.WriteLine($"Query: {query}");
                }
                else if(query != "" && fragment != "")
                {
                    Console.WriteLine($"Query: {query}");
                    Console.WriteLine($"Fragment: {fragment}");
                }

            }
            else
            {
                Console.WriteLine(invalidUrl);
            }
        }
    }
}

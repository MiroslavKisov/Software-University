namespace RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var paths = new List<List<string>>();

            string input;
            while ((input = Console.ReadLine())!= "END")
            {
                var pathArgs = input.Split('/').ToList();
                pathArgs = pathArgs.Where(e => e != "").ToList();
                paths.Add(pathArgs);
            }

            input = Console.ReadLine();

            var requestArgs = input.Split('/');
            var requestMethod = requestArgs[0].ToLower();
            var requestPath = requestArgs[1].Split(" ").FirstOrDefault();
            var requestProtocol = requestArgs[1].Split(" ").LastOrDefault();
            var protocolVersion = requestArgs[2];
            var isOk = false;

            foreach (var path in paths)
            {
                var pathName = path[0];
                var pathMethod = path[1];

                if (pathName == requestPath && pathMethod == requestMethod.ToLower().TrimEnd())
                {
                    Console.WriteLine($"{requestArgs[2]} 200 OK");
                    Console.WriteLine("Content-Length: 2");
                    Console.WriteLine("Content-Type: text/plain");
                    Console.WriteLine();
                    Console.WriteLine("OK");
                    isOk = true;
                    break;
                }
            }

            if (!isOk)
            {
                Console.WriteLine($"{requestProtocol}/{requestArgs[2]} 404 NotFound");
                Console.WriteLine("Content-Length: 9");
                Console.WriteLine("Content-Type: text/plain");
                Console.WriteLine();
                Console.WriteLine("NotFound");
            }
        }
    }
}

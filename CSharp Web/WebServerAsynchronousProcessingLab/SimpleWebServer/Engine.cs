namespace SimpleWebServer
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private const string IPadress = "127.0.0.1";
        private const int bufferSize = 1024;

        public void Run()
        {
            IPAddress address = IPAddress.Parse(IPadress); 
            int port = 1999;
            TcpListener listener = new TcpListener(address, port);
            listener.Start();
            Console.WriteLine("Server started");
            Console.WriteLine($"Listening to TCP clients on {IPadress}:{port}");

            var task = Task.Run(() => ConnectWithTcpClient(listener));
            task.Wait();
        }

        private async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");

                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected.");

                byte[] buffer = new byte[bufferSize];
                client.GetStream().Read(buffer, 0, bufferSize);

                var message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(message);

                byte[] data = Encoding.UTF8.GetBytes("Hello from server :D");
                client.GetStream().Write(data, 0, data.Length);

                Console.WriteLine("Closing connection");
                client.GetStream().Dispose();
            }
        }
    }
}

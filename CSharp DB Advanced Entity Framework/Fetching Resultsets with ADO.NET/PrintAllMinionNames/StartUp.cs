using PrintAllMinionNames.Factories;
using PrintAllMinionNames.Interfaces;
using PrintAllMinionNames.Models;
using System;

namespace PrintAllMinionNames
{
    public class StartUp
    {
        public static void Main()
        {
            IConnectionFactory connectionFactory = new ConnectionFactory();
            ICommandFactory commandFactory = new CommandFactory();

            IConnection connection = new Connection(connectionFactory, commandFactory);

            connection.RunConnection();
        }
    }
}

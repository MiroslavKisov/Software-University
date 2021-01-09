using IncreaseMinionAge.Factories;
using IncreaseMinionAge.Interfaces;
using IncreaseMinionAge.Madels;
using System;

namespace IncreaseMinionAge
{
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Please enter minion Id's: ");
            string minionId = Console.ReadLine();

            ICommandFactory commandFactory = new CommandFactory();
            IConnectionFactory connectionFactory = new ConnectionFactory();

            IConnection connection = new Connection(connectionFactory, commandFactory);

            connection.RunConnection(minionId);
        }
    }
}

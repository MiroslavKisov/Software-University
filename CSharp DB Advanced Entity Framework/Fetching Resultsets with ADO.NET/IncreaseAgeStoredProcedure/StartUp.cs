using IncreaseAgeStoredProcedure.Factories;
using IncreaseAgeStoredProcedure.Interfaces;
using IncreaseAgeStoredProcedure.Models;
using System;

namespace IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Please enter minion ID: ");
            int minionId = int.Parse(Console.ReadLine());

            ICommandFactory commandFactory = new CommandFactory();
            IConnectionFactory connectionFactory = new ConnectionFactory();

            IConnection connection = new Connection(connectionFactory, commandFactory);

            connection.RunConnection(minionId);
        }
    }
}

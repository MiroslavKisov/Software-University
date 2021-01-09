using RemoveVillain.Factories;
using RemoveVillain.Interfaces;
using RemoveVillain.Models;
using System;

namespace RemoveVillain
{
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Please enter villainId: ");
            int villainId = int.Parse(Console.ReadLine());

            ICommandFactory commandFactory = new CommandFactory();
            IConnectionFactory connectionFactory = new ConnectionFactory();

            IConnection connection = new Connection(connectionFactory, commandFactory);

            connection.RunConnection(villainId);
        }
    }
}

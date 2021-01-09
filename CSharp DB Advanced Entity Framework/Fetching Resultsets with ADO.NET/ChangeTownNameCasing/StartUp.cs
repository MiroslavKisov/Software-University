using ChangeTownNameCasing.Factories;
using ChangeTownNameCasing.Interfaces;
using ChangeTownNameCasing.Models;
using System;

namespace ChangeTownNameCasing
{
    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Please enter Country name: ");
            string countryName = Console.ReadLine();

            IFactory commandFactory = new SqlCommandFactory();
            IConnectionFactory connectionFactory = new ConnectionFactory();

            Connection connection = new Connection(connectionFactory, commandFactory);

            connection.RunConnection(countryName);

        }
    }
}

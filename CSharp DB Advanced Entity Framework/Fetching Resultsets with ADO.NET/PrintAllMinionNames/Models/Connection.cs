using InitialSetup;
using PrintAllMinionNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrintAllMinionNames.Models
{
    internal class Connection : IConnection
    {
        private IConnectionFactory connectionFactory;
        private SqlConnection connection;
        private CommandQuery query;

        public Connection(IConnectionFactory factory, ICommandFactory commFactory)
        {
            connectionFactory = factory;
            connection = connectionFactory.InitConection(ConnectionConfiguration.connection);
            query = new CommandQuery(commFactory);
        }

        public void RunConnection()
        {
            connection.Open();
            connection.ChangeDatabase("MinionsDB");

            var minions = query.GetAllMinions(QueryHolder.selectMinionNames, connection);

            PrintAllMinionNames(minions);

            connection.Close();
        }

        private void PrintAllMinionNames(List<string> minions)
        {
            if (minions.Count % 2 != 0)
            {
                for (int i = 0; i < minions.Count / 2; i++)
                {
                    Console.WriteLine(minions[0 + i]);
                    Console.WriteLine(minions[(minions.Count - 1) - i]);
                }

                Console.WriteLine(minions[minions.Count / 2]);
            }
            else
            {
                for (int i = 0; i < minions.Count / 2; i++)
                {
                    Console.WriteLine(minions[0 + i]);
                    Console.WriteLine(minions[(minions.Count - 1) - i]);
                }
            }
        }
    }
}

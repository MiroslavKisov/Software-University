using IncreaseMinionAge.Interfaces;
using InitialSetup;
using System;
using System.Data.SqlClient;

namespace IncreaseMinionAge.Madels
{
    internal class Connection : IConnection
    {
        private IConnectionFactory connectionFactory;
        private SqlConnection connection;
        private CommandQuery query;
        private IParser parser;

        public Connection(IConnectionFactory factory, ICommandFactory commFactory)
        {
            connectionFactory = factory;
            connection = connectionFactory.InitConection(ConnectionConfiguration.connection);
            query = new CommandQuery(commFactory);
            parser = new Parser();
        }

        public void RunConnection(string input)
        {
            var ids = parser.ParseInput(input);

            connection.Open();
            connection.ChangeDatabase("MinionsDB");

            for (int i = 0; i < ids.Length; i++)
            {
                query.IncreaseMinionAge(QueryHolder.updateMinionAge, connection, ids[i]);
                query.UpdateMinionName(QueryHolder.updateTitleCase, connection, ids[i]);
            }

            query.PrintAllMinions(QueryHolder.selectAllMinions, connection);

            connection.Close();
        }
    }
}

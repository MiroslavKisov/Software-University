using IncreaseAgeStoredProcedure.Interfaces;
using InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IncreaseAgeStoredProcedure.Models
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

        public void RunConnection(int minionId)
        {
            connection.Open();
            connection.ChangeDatabase("MinionsDB");

            query.UpdateMinionAge(QueryHolder.execProcedure, connection, minionId);

            query.PrintMinionInfo(QueryHolder.selectMinion, connection, minionId);

            connection.Close();
        }
    }
}

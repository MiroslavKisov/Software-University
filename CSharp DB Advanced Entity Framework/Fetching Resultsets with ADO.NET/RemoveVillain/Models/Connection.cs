using InitialSetup;
using RemoveVillain.Interfaces;
using System;
using System.Data.SqlClient;

namespace RemoveVillain.Models
{
    internal class Connection : IConnection
    {
        private IConnectionFactory connectionFactory;
        private SqlConnection connection;
        private CommandQuery query;

        public Connection(IConnectionFactory factory, ICommandFactory comFactory)
        {
            connectionFactory = factory;
            connection = connectionFactory.InitConection(ConnectionConfiguration.connection);
            query = new CommandQuery(comFactory);
        }

        public void RunConnection(int villainId)
        {
            connection.Open();
            connection.ChangeDatabase("MinionsDB");

            SqlTransaction transaction = connection.BeginTransaction();

            string villainName = query.GetVillainName(QueryHolder.selectVillainName, connection, villainId, transaction);

            try
            {
                if (villainName != null)
                {
                    int numberOfMinionsReleased = query.DeleteMinionsAndVillain(QueryHolder.deleteVillainFromMappingTable, connection, villainId, transaction);
                    query.DeleteVillain(QueryHolder.deleteVillain, connection, villainId, transaction);
                    query.DeleteMinionsAndVillain(QueryHolder.deleteVillainFromMappingTable, connection, villainId, transaction);
                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{numberOfMinionsReleased} minions were released.");
                }
                else
                {
                    Console.WriteLine("No such villain was found.");
                }
            }
            catch (SqlException e)
            {
                transaction.Rollback();
            }

            transaction.Commit();
            connection.Close();
        }
    }
}

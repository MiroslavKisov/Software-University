using ChangeTownNameCasing.Interfaces;
using InitialSetup;
using System;
using System.Data.SqlClient;

namespace ChangeTownNameCasing.Models
{
    internal class Connection : IConnection
    {
        private IConnectionFactory connectionFactory;
        private SqlConnection connection;
        private CommandQuery query;

        public Connection(IConnectionFactory factory, IFactory commFactory)
        {
            connectionFactory = factory;
            connection = connectionFactory.InitConection(ConnectionConfiguration.connection);
            query = new CommandQuery(commFactory);
        }

        public void RunConnection(string countryName)
        {
            using (connection)
            {
                connection.Open();
                connection.ChangeDatabase("MinionsDB");

                int numberOfTowns = query.GetNumberOfAffectedTowns(QueryHolder.selectNumberOfTowns, connection, countryName);

                if (numberOfTowns == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    int countryId = query.GetCountryID(QueryHolder.selectCountryId, connection, countryName);
                    query.UpdateTowns(QueryHolder.updateTowns, connection, countryId);

                    var townsAffected = query.GetAffectedTowns(QueryHolder.selectTownsByCountryId, connection, countryId);

                    Console.WriteLine($"{numberOfTowns} town names were affected");
                    Console.WriteLine("["+ $"{string.Join(", ", townsAffected)}" +"]");
                }

                connection.Close();
            }
        }
    }
}

using ChangeTownNameCasing.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChangeTownNameCasing.Models
{
    internal class CommandQuery
    {
        private IFactory commandFactory;

        public CommandQuery(IFactory factory)
        {
            commandFactory = factory;
        }

        public int GetCountryID(string query, SqlConnection connection, string countryName)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@countryName", countryName);

                return (int)sqlCommand.ExecuteScalar();
            }
        }

        public void UpdateTowns(string query, SqlConnection connection, int countryCode)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@countryCode", countryCode);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public int GetNumberOfAffectedTowns(string query, SqlConnection connection, string countryName)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@countryName", countryName);

                return (int)sqlCommand.ExecuteScalar();
            }
        }

        public List<string> GetAffectedTowns(string query, SqlConnection connection, int countryCode)
        {
            var townsAffected = new List<string>();

            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@countryCode", countryCode);

                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    townsAffected.Add((string)reader[0]);
                }
            }

            return townsAffected;
        }
    }
}

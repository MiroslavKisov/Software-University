using RemoveVillain.Interfaces;
using System.Data.SqlClient;

namespace RemoveVillain.Models
{
    internal class CommandQuery
    {
        private ICommandFactory commandFactory;

        public CommandQuery(ICommandFactory factory)
        {
            commandFactory = factory;
        }

        public int DeleteMinionsAndVillain(string query, SqlConnection connection, int villainId, SqlTransaction transaction)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection, transaction))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public string GetVillainName(string query, SqlConnection connection, int villainId, SqlTransaction transaction)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection, transaction))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                return (string)sqlCommand.ExecuteScalar();
            }
        }

        public void DeleteVillain(string query, SqlConnection connection, int villainId, SqlTransaction transaction)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection, transaction))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}

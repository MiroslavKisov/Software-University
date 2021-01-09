using RemoveVillain.Interfaces;
using System.Data.SqlClient;

namespace RemoveVillain.Factories
{
    internal class CommandFactory : ICommandFactory
    {
        public SqlCommand CreateCommand(string query, SqlConnection connection, SqlTransaction transaction)
        {
            return new SqlCommand(query, connection, transaction);
        }
    }
}

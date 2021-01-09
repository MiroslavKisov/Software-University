using PrintAllMinionNames.Interfaces;
using System.Data.SqlClient;

namespace PrintAllMinionNames.Factories
{
    internal class CommandFactory : ICommandFactory
    {
        public SqlCommand CreateCommand(string query, SqlConnection connection)
        {
            return new SqlCommand(query, connection);
        }
    }
}

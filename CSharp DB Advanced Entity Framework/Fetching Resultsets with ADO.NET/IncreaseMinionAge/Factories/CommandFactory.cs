using IncreaseMinionAge.Interfaces;
using System.Data.SqlClient;

namespace IncreaseMinionAge.Factories
{
    internal class CommandFactory : ICommandFactory
    {
        public SqlCommand CreateCommand(string query, SqlConnection connection)
        {
            return new SqlCommand(query, connection);
        }
    }
}

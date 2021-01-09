using ChangeTownNameCasing.Interfaces;
using System.Data.SqlClient;

namespace ChangeTownNameCasing.Factories
{
    internal class SqlCommandFactory : IFactory
    {
        public SqlCommand CreateCommand(string query, SqlConnection connection)
        {
            return new SqlCommand(query, connection);
        }
    }
}

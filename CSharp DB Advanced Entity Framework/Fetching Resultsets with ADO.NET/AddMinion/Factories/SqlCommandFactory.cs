using AddMinion.Interfaces;
using System.Data.SqlClient;

namespace AddMinion.Factories
{
    internal class SqlCommandFactory : IFactory
    {
        public SqlCommand CreateCommand(string query, SqlConnection connection)
        {
            return new SqlCommand(query, connection);
        }
    }
}

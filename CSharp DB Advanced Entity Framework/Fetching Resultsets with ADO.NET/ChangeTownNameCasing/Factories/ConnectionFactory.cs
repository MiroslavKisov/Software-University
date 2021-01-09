using ChangeTownNameCasing.Interfaces;
using System.Data.SqlClient;

namespace ChangeTownNameCasing.Factories
{
    internal class ConnectionFactory : IConnectionFactory
    {
        public SqlConnection InitConection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

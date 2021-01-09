using RemoveVillain.Interfaces;
using System.Data.SqlClient;

namespace RemoveVillain.Factories
{
    internal class ConnectionFactory : IConnectionFactory
    {
        public SqlConnection InitConection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

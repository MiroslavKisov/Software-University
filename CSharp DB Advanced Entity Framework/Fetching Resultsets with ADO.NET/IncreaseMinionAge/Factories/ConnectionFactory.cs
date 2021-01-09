using IncreaseMinionAge.Interfaces;
using System.Data.SqlClient;

namespace IncreaseMinionAge.Factories
{
    internal class ConnectionFactory : IConnectionFactory
    {
        public SqlConnection InitConection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

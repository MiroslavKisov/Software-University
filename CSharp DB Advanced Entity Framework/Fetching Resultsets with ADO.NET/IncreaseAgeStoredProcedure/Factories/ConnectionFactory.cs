using IncreaseAgeStoredProcedure.Interfaces;
using System.Data.SqlClient;

namespace IncreaseAgeStoredProcedure.Factories
{
    internal class ConnectionFactory : IConnectionFactory
    {
        public SqlConnection InitConection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

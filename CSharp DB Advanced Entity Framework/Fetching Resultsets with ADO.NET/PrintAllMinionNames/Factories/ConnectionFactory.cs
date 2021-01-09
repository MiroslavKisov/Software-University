using PrintAllMinionNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PrintAllMinionNames.Factories
{
    internal class ConnectionFactory : IConnectionFactory
    {
        public SqlConnection InitConection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

using System.Data.SqlClient;

namespace PrintAllMinionNames.Interfaces
{
    internal interface IConnectionFactory
    {
        SqlConnection InitConection(string connectionString);
    }
}

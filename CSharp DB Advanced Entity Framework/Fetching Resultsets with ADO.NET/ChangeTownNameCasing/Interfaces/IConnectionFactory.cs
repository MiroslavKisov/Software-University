using System.Data.SqlClient;

namespace ChangeTownNameCasing.Interfaces
{
    internal interface IConnectionFactory
    {
        SqlConnection InitConection(string connectionString);
    }
}

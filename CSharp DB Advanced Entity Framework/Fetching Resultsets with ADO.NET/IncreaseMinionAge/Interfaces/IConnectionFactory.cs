using System.Data.SqlClient;

namespace IncreaseMinionAge.Interfaces
{
    internal interface IConnectionFactory
    {
        SqlConnection InitConection(string connectionString);
    }
}

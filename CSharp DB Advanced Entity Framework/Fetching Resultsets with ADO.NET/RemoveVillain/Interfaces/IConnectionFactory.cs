using System.Data.SqlClient;

namespace RemoveVillain.Interfaces
{
    internal interface IConnectionFactory
    {
        SqlConnection InitConection(string connectionString);
    }
}

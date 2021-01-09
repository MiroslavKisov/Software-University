using System.Data.SqlClient;

namespace AddMinion.Interfaces
{
    internal interface IFactory
    {
        SqlCommand CreateCommand(string query, SqlConnection connection);
    }
}

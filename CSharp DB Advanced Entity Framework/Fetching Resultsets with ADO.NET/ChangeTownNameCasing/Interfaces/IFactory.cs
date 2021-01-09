using System.Data.SqlClient;

namespace ChangeTownNameCasing.Interfaces
{
    internal interface IFactory
    {
        SqlCommand CreateCommand(string query, SqlConnection connection);
    }
}

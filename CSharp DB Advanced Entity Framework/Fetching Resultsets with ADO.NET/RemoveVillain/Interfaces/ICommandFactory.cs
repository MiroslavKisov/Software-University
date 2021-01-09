using System.Data.SqlClient;

namespace RemoveVillain.Interfaces
{
    internal interface ICommandFactory
    {
        SqlCommand CreateCommand(string query, SqlConnection connection, SqlTransaction transaction);
    }
}

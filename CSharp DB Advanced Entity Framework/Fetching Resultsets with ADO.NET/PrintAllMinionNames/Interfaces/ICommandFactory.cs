using System.Data.SqlClient;

namespace PrintAllMinionNames.Interfaces
{
    internal interface ICommandFactory
    {
        SqlCommand CreateCommand(string command, SqlConnection connection);
    }
}

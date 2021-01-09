using System.Data.SqlClient;

namespace IncreaseMinionAge.Interfaces
{
    internal interface ICommandFactory
    {
        SqlCommand CreateCommand(string command, SqlConnection connection);
    }
}

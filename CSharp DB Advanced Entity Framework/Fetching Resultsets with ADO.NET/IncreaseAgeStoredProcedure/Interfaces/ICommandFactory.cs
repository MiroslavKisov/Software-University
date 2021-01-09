using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IncreaseAgeStoredProcedure.Interfaces
{
    internal interface ICommandFactory
    {
        SqlCommand CreateCommand(string command, SqlConnection connection);
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IncreaseAgeStoredProcedure.Interfaces
{
    internal interface IConnectionFactory
    {
        SqlConnection InitConection(string connectionString);
    }
}

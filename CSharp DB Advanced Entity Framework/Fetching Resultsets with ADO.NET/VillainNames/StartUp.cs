using InitialSetup;
using System;
using System.Data.SqlClient;

namespace VillainNames
{
    public class StartUp
    {
        public static void Main()
        { 

            using (var connection = new SqlConnection(ConnectionConfiguration.connection))
            {
                connection.Open();

                connection.ChangeDatabase("MinionsDB");

                const string query = @"SELECT v.Name, COUNT(*) AS MinionCount FROM Villains AS v JOIN"+
                                      " MinionsVillains AS mv ON v.Id = mv.VillainId JOIN Minions AS m ON" +
                                      " mv.MinionId = m.Id GROUP BY v.Name HAVING COUNT(*) > 3 ORDER BY MinionCount DESC";

                ExecQuery(connection, query);

                connection.Close();
            }
        }

        private static void ExecQuery(SqlConnection connection, string queryCommand)
        {
            using (var sqlCommand = new SqlCommand(queryCommand, connection))
            {
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string villainName = (string)reader[0];
                    int minionsCount = (int)reader[1];

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }
    }
}

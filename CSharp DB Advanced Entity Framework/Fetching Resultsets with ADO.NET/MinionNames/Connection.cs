using InitialSetup;
using System;
using System.Data.SqlClient;

namespace MinionNames
{
    internal class Connection
    {
        public SqlConnection connection;

        public Connection()
        {
            connection = new SqlConnection(ConnectionConfiguration.connection);
        }

        public void RunConnection(int villainId)
        {
            using (connection)
            {
                connection.Open();

                connection.ChangeDatabase("MinionsDB");

                const string sqlQueryVillainName = @"SELECT Name FROM Villains WHERE Id = @villainId";

                const string sqlQueryMinionsNames = @"SELECT m.Name, m.Age FROM Villains AS v JOIN MinionsVillains AS mv ON" +
                    " v.Id = mv.VillainId JOIN Minions AS m ON mv.MinionId = m.Id WHERE VillainId = @villainId";

                GetvillainName(sqlQueryVillainName, connection, villainId);

                GetMinions(sqlQueryMinionsNames, connection, villainId);

                connection.Close();
            }
        }

        private void GetvillainName(string sqlQueryVillainName, SqlConnection connection, int villainId)
        {
            using (var sqlCommand = new SqlCommand(sqlQueryVillainName, connection))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                string villainName = (string)sqlCommand.ExecuteScalar();

                Console.WriteLine($"Villain: {villainName}");
            }
        }

        private void GetMinions(string sqlQuery, SqlConnection connection, int villainId)
        {
            using (var sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                var reader = sqlCommand.ExecuteReader();
                int index = 1;

                while (reader.Read())
                {
                    string minionName = (string)reader[0];
                    int minionAge = (int)reader[1];
                    Console.WriteLine($"{index++}.{minionName} {minionAge}");
                }
            }
        }
    }
}

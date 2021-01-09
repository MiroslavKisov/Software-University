using IncreaseAgeStoredProcedure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IncreaseAgeStoredProcedure.Models
{
    internal class CommandQuery
    {
        private ICommandFactory commandFactory;

        public CommandQuery(ICommandFactory factory)
        {
            commandFactory = factory;
        }

        public void UpdateMinionAge(string query, SqlConnection connection, int minionId)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@minionId", minionId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void PrintMinionInfo(string query, SqlConnection connection, int minionId)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@minionId", minionId);

                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader[0];
                    int age = (int)reader[1];

                    Console.WriteLine($"{name} - {age} years old");
                }
            }
        }
    }
}

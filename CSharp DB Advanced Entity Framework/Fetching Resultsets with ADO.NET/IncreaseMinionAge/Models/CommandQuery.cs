using IncreaseMinionAge.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IncreaseMinionAge.Madels
{
    internal class CommandQuery
    {
        private ICommandFactory commandFactory;

        public CommandQuery(ICommandFactory factory)
        {
            commandFactory = factory;
        }

        public void IncreaseMinionAge(string query, SqlConnection connection, int minionId)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@minionId", minionId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateMinionName(string query, SqlConnection connection, int minionId)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@minionId", minionId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateToTitleCase(string query, SqlConnection connection, int minionId)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@minionId", minionId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void PrintAllMinions(string query, SqlConnection connection)
        {
            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader[0];
                    int age = (int)reader[1];
                    Console.WriteLine($"{name} {age}");
                }
            }
        }
    }
}

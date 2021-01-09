using PrintAllMinionNames.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PrintAllMinionNames.Models
{
    internal class CommandQuery
    {
        private ICommandFactory commandFactory;

        public CommandQuery(ICommandFactory factory)
        {
            commandFactory = factory;
        }

        public List<string> GetAllMinions(string query, SqlConnection connection)
        {
            List<string> minions = new List<string>();

            using (var sqlCommand = commandFactory.CreateCommand(query, connection))
            {
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    minions.Add((string)reader[0]);
                }
            }

            return minions;
        }
    }
}

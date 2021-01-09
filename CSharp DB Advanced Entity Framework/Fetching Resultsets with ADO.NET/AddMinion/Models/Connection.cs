using System;
using System.Data.SqlClient;
using InitialSetup;
using AddMinion.Interfaces;
using AddMinion.Models;
using AddMinion.Factories;

namespace AddMinion
{
    internal class Connection : IConnection
    {
        private SqlConnection connection;
        private IParser parseInp;
        private string minionData;
        private string villainData;
        private IFactory factory;

        public Connection(IParser parser, string minionInfo, string villainInfo)
        {
            connection = new SqlConnection(ConnectionConfiguration.connection);
            parseInp = parser;
            minionData = minionInfo;
            villainData = villainInfo;
            factory = new SqlCommandFactory();
        }

        public void RunConnection()
        {
            using (connection)
            {
                string[] minionArgs = parseInp.ParseInput(minionData);
                string[] villainArgs = parseInp.ParseInput(villainData);

                int townId = 0;
                int minionId = 0;
                int villainId = 0;

                connection.Open();
                connection.ChangeDatabase("MinionsDB");

                if(!CheckTownExistence(QueryHolder.selectTownId, connection, minionArgs))
                {
                    InsertTown(QueryHolder.insertTownIntoTowns, connection, minionArgs);
                    townId = GetTownId(QueryHolder.selectTownCount, connection, minionArgs);
                }

                if (!CheckVillainExistence(QueryHolder.selectVillainId, connection, villainArgs))
                {
                    InsertVillain(QueryHolder.insertVillain, connection, villainArgs);
                }

                townId = GetTownId(QueryHolder.selectTownCount, connection, minionArgs);

                InsertMinionInMinionTable(QueryHolder.insertMinionInMinionsTable, connection, minionArgs, townId);

                minionId = GetMinionId(QueryHolder.selectMinionCount, connection, minionArgs);

                villainId = GetVillianId(QueryHolder.selectVillainCount, connection, villainArgs);

                InsertMinionAndVillain(QueryHolder.insertVillainAndMinionInMappingTable, connection, villainId, minionId, minionArgs, villainArgs);

                connection.Close();
            }
        }

        private void InsertTown(string query, SqlConnection connection, string[] minionArgs)
        {
            string townName = minionArgs[2];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.insertTownIntoTowns, connection))
            {
                sqlCommand.Parameters.AddWithValue("@townName", townName);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }

        private void InsertVillain(string query, SqlConnection connection, string[] villainArgs)
        {
            string villainName = villainArgs[0];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.insertVillain, connection))
            {
                sqlCommand.Parameters.AddWithValue(@"villainName", villainName);
                sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private void InsertMinionAndVillain(string query, SqlConnection connection, int villainId, int minionId, string[] minionArgs, string[] villainArgs)
        {
            string minionName = minionArgs[0];
            string villainName = villainArgs[0];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.insertVillainAndMinionInMappingTable, connection))
            {
                sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                sqlCommand.Parameters.AddWithValue("@minionId", minionId);

                sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private int GetMinionId(string query, SqlConnection connection, string[] minionArgs)
        {
            string minionName = minionArgs[0];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.selectMinionCount, connection))
            {
                sqlCommand.Parameters.AddWithValue("@minionName", minionName);
                return (int)sqlCommand.ExecuteScalar();
            }
        }

        private int GetVillianId(string query, SqlConnection connection, string[] villainArgs)
        {
            string villainName = villainArgs[0];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.selectVillainId, connection))
            {
                sqlCommand.Parameters.AddWithValue("@villainName", villainName);
                return (int)sqlCommand.ExecuteScalar();
            }
        }

        private bool CheckVillainExistence(string query, SqlConnection connection, string[] villainArgs)
        {
            string villianName = villainArgs[0];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.selectVillainId, connection))
            {
                sqlCommand.Parameters.AddWithValue("@villainName", villianName);
                return sqlCommand.ExecuteScalar() != null;
            }
        }

        private void InsertMinionInMinionTable(string query, SqlConnection connection, string[] minionArgs, int townId)
        {
            string minionName = minionArgs[0];
            int minionAge = int.Parse(minionArgs[1]);

            using (var sqlCommand = factory.CreateCommand(QueryHolder.insertMinionInMinionsTable, connection))
            {
                sqlCommand.Parameters.AddWithValue("@minionName", minionName);
                sqlCommand.Parameters.AddWithValue("@minionAge", minionAge);
                sqlCommand.Parameters.AddWithValue("@townId", townId);

                sqlCommand.ExecuteNonQuery();
            }
        }

        private int GetTownId(string query, SqlConnection connection, string[] minionArgs)
        {
            string townName = minionArgs[2];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.selectTownId, connection))
            {
                sqlCommand.Parameters.AddWithValue("@townName", townName);
                return (int)sqlCommand.ExecuteScalar();
            }
        }

        private bool CheckTownExistence(string query, SqlConnection connection, string[] minionArgs)
        {
            string townName = minionArgs[2];

            using (var sqlCommand = factory.CreateCommand(QueryHolder.selectTownId, connection))
            {
                sqlCommand.Parameters.AddWithValue("@townName", townName);
                return sqlCommand.ExecuteScalar() != null;
            }
        }
    }
}

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InitialSetup
{
    public class StartUp
    {
        public static void Main()
        {
            var connection = new SqlConnection(ConnectionConfiguration.connection);

            using (connection)
            {
                var commands = new List<string>();

                connection.Open();

                const string createDatabase = @"CREATE DATABASE MinionsDB";
                ExecQuery(createDatabase, connection);

                connection.ChangeDatabase("MinionsDB");

                const string createTableCountries = @"CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";
                commands.Add(createTableCountries);

                const string createTableTowns = @"CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50)," +
                                                " CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
                commands.Add(createTableTowns);

                const string createTableMinions = @"CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30),"+
                                                  " Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
                commands.Add(createTableMinions);

                const string createTableEvilnessFactors = @"CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
                commands.Add(createTableEvilnessFactors);

                const string createTableVillains = @"CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50)," +
                                                     " EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
                commands.Add(createTableVillains);

                const string createTableMinionsVillains = @"CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES"+
                                                            " Minions(Id), VillainId INT FOREIGN KEY REFERENCES" +
                                                            " Villains(Id),CONSTRAINT" +
                                                             " PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
                commands.Add(createTableMinionsVillains);

                const string insertIntoCountries = @"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'), ('England'),"+
                                                   " ('Cyprus'), ('Germany'), ('Norway')";
                commands.Add(insertIntoCountries);

                const string insertIntoTowns = @"INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1), ('Varna', 1)," +
                                               " ('Burgas', 1), ('Sofia', 1), ('London', 2), ('Southampton', 2), ('Bath', 2), " +
                                               "('Liverpool', 2), ('Berlin', 3), ('Frankfurt', 3), ('Oslo', 4)";
                commands.Add(insertIntoTowns);

                const string insertIntoMinions = @"INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3), ('Kevin', 1, 1),"+
                                                 " ('Bob ', 32, 6),('Simon', 45, 3), ('Cathleen', 11, 2), ('Carry ', 50, 10), " +
                                                 "('Becky', 125, 5), ('Mars', 21, 1), ('Misho', 5, 10), ('Zoe', 125, 5), " +
                                                 "('Json', 21, 1)";
                commands.Add(insertIntoMinions);

                const string insertIntoEvilnessFactors = @"INSERT INTO EvilnessFactors (Name) VALUES"+ 
                                                         " ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
                commands.Add(insertIntoEvilnessFactors);

                const string insertIntoVillians = @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2), ('Victor',1)," + 
                                                  " ('Jilly',3), ('Miro',4), ('Rosen',5), ('Dimityr',1), ('Dobromir',2)";
                commands.Add(insertIntoVillians);

                const string insertIntoMinionsVillians = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),"+ 
                                                         " (1,1), (5,7), (3,5), (2,6), (11,5), (8,4), (9,7), (7,1), (1,3), " +
                                                         "(7,3), (5,3), (4,3), (1,2), (2,1), (2,7)";
                commands.Add(insertIntoMinionsVillians);

                

                for (int i = 0; i < commands.Count; i++)
                {
                    ExecQuery(commands[i], connection);
                }


                connection.Close();
            }

        }

        private static void ExecQuery(string commandQuery, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(commandQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}

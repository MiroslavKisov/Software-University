using System;

namespace AddMinion.Models
{
    internal class QueryHolder
    {
        public const string selectTownId = @"SELECT TOP 1 Id FROM Towns WHERE Name = @townName";

        public const string selectTownCount = @"SELECT COUNT(*) FROM Towns";

        public const string selectVillainId = @"SELECT TOP 1 Id FROM Villains WHERE Name = @villainName";

        public const string selectVillainCount = @"SELECT COUNT(*) FROM Villains";

        public const string selectMinionCount = "SELECT COUNT(*) FROM Minions";

        public const string insertMinionInMinionsTable = @"INSERT INTO Minions(Name, Age, TownId) VALUES" +
                                                              " (@minionName, @minionAge, @townId)";

        public const string insertTownIntoTowns = @"INSERT INTO Towns(Name, CountryCode) VALUES (@townName, 1)";

        public const string insertVillainAndMinionInMappingTable = @"INSERT INTO MinionsVillains(MinionId, VillainId)" +
                                                                   " VALUES(@minionId, @villainId)";

        public const string insertVillain = @"INSERT INTO Villains(Name, EvilnessFactorId) VALUES (@villainName, 4)";
    }
}

namespace RemoveVillain.Models
{
    internal class QueryHolder
    {
        public const string deleteVillainFromMappingTable = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

        public const string selectVillainName = @"SELECT Name FROM Villains WHERE Id = @villainId";

        public const string deleteVillain = @"DELETE FROM Villains WHERE Id = @villainId";
    }
}

namespace IncreaseMinionAge.Madels
{
    internal class QueryHolder
    {
        public const string updateMinionAge = @"UPDATE Minions SET Age += 1 WHERE Id = @minionId";

        public const string selectMinionAge = @"SELECT Name FROM Minions WHERE Id = @minionId";

        public const string updateTitleCase = @"UPDATE Minions SET Name = UPPER(LEFT(Name, 1))" + 
                                               " + LOWER(SUBSTRING(Name, 2, LEN(Name))) WHERE Id = @minionId";

        public const string selectAllMinions = @"SELECT Name, Age FROM Minions";
    }
}

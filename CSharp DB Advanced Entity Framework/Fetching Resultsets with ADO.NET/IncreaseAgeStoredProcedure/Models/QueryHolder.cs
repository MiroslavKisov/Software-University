namespace IncreaseAgeStoredProcedure.Models
{
    internal class QueryHolder
    {
        public const string execProcedure = @"EXEC usp_GetOlder @minionId";

        public const string selectMinion = @"SELECT Name, Age FROM Minions WHERE Id = @minionId";
    }
}

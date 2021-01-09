namespace ChangeTownNameCasing.Models
{
    internal class QueryHolder
    {
        public const string selectCountryId = @"SELECT Id FROM Countries WHERE Name = @countryName";

        public const string updateTowns = @"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = @countryCode";

        public const string selectNumberOfTowns = @"SELECT COUNT(*) FROM Countries AS c" +
                                                  " JOIN Towns As t ON c.Id = t.CountryCode" +
                                                  " WHERE c.Name = @countryName";

        public const string selectTownsByCountryId = @"SELECT Name FROM Towns WHERE CountryCode = @countryCode";
    }
}

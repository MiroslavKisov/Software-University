namespace P03_FootballBetting.Data.Interfaces
{
    public interface IFactory
    {
        FootballBettingContext CreateContext();
    }
}

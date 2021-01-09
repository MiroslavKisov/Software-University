using P03_FootballBetting.Data.Interfaces;

namespace P03_FootballBetting.Data.Factories
{
    public class ContextFactory : IFactory
    {
        public FootballBettingContext CreateContext()
        {
            return new FootballBettingContext();
        }
    }
}

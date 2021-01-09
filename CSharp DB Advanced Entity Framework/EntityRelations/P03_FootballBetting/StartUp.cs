using P03_FootballBetting.Data;
using P03_FootballBetting.Data.Factories;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            ContextFactory factory = new ContextFactory();

            DatabaseConfig db = new DatabaseConfig(factory);

            db.InitDatabase();
        }
    }
}

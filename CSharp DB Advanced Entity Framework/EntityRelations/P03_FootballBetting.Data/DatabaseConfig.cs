using P03_FootballBetting.Data.Factories;

namespace P03_FootballBetting.Data
{
    public class DatabaseConfig
    {
        private ContextFactory contextFactory;

        public DatabaseConfig(ContextFactory factory)
        {
            this.contextFactory = factory;
        }

        public void InitDatabase()
        {
            using (var db = this.contextFactory.CreateContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void DeleteDatabase()
        {
            using (var db = this.contextFactory.CreateContext())
            {
                db.Database.EnsureDeleted();
            }
        }
    }
}

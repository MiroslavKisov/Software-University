using P01_StudentSystem.Factories;

namespace P01_StudentSystem
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

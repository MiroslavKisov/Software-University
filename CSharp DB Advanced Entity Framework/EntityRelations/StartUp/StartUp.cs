using P01_StudentSystem;
using P01_StudentSystem.Factories;

namespace StartUp
{
    public class StartUp
    {
        public static void Main()
        {
            ContextFactory contextFactory = new ContextFactory();

            DatabaseConfig db = new DatabaseConfig(contextFactory);

            db.InitDatabase();

        }
    }
}

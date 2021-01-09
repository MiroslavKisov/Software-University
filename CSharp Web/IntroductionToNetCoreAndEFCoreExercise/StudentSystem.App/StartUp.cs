namespace StudentSystem.App
{
    using Microsoft.EntityFrameworkCore;
    using StudentSystem.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new StudentSystemContext())
            {
                ResetDatabase(db);
                var engine = new Engine(db);
                engine.SeedData();

                //Task 1
                engine.ListAllStudentsAndTheirHomeWorkSubmissions();

                //Task 2
                engine.ListAllCoursesWithTheirCorrespondingResources();

                //Task 3
                engine.ListAllCoursesWithMoreThanFourResources();

                //Task 4
                engine.ListAllCoursesWhichWereActiveOnaGivenDate();

                //Task 5
                engine.CalculateNumberOfCoursesAndTheirPrice();

                //Task 6
                engine.ListAllCoursesWithTheirCorrespondingResourcesAndLicenses();

                //Task 7
                engine.ListAllStudentsWithTheirCoursesResourcesAndLicenses();
            }
        }

        private static void ResetDatabase(StudentSystemContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.Migrate();
        }
    }
}

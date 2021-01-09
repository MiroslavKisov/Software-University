namespace ManyToManyRelation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new Context())
            {
                ResetDatabase(db);
            }
        }

        private static void ResetDatabase(Context db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}

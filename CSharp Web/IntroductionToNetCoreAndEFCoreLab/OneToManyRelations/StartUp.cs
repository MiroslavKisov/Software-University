namespace OneToManyRelations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new Context())
            {
                try
                {
                    ResetDatabase(db);
                    SeedData(db);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    db.Database.RollbackTransaction();
                }
            }
        }

        private static void SeedData(Context db)
        {
            string[] employeeNames = { "Pesho", "Gosho", "Mimi", "Didi", "Pena", "Stacey", "Lacy", "Teddy", "Rico", "John", "Jimmy", "Dave", "Vayetsy", "Rodrigo", "Stephanie", "Larry", "Max", "Michelle", "Dwayne", "Sergio", "Miguel" };

            string[] departmentNames = { "Engineering", "Sales", "Production", "Security" };

            var employees = new List<Employee>();
            var departments = new List<Department>();
            var employeeCounter = 0;
            var seedStep = employeeNames.Length / departmentNames.Length;
            var departmentId = 1;

            db.Database.BeginTransaction();

            foreach (var departmentName in departmentNames)
            {
                var department = new Department
                {
                    Name = departmentName,
                };

                if (IsValid(department))
                {
                    departments.Add(department);
                }
            }

            db.AddRange(departments);
            db.SaveChanges();

            foreach (var employeeName in employeeNames)
            {
                if (employeeCounter == seedStep)
                {
                    departmentId++;
                    employeeCounter = 0;
                    if (departmentId > departmentNames.Length)
                    {
                        departmentId = departmentNames.Length;
                    }
                }

                var employee = new Employee
                {
                    Name = employeeName,
                    DepartmentId = departmentId,
                    ManagerId = null,
                };

                if (IsValid(employee))
                {
                    employees.Add(employee);
                }

                employeeCounter++;
            }

            var employeesFiltered = employees.Where(e => e.Name != "Pesho").ToList();

            foreach (var employee in employeesFiltered)
            {
                employee.ManagerId = 1;
            }

            db.Employees.AddRange(employees);
            db.SaveChanges();

            db.Database.CommitTransaction();
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

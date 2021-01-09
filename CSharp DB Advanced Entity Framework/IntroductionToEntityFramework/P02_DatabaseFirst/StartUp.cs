using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Factories;
using P02_DatabaseFirst.Solutions;
using System;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main()
        {
            ContextFactory contextFactory = new ContextFactory();

            SoftUniContext softUniContext = contextFactory.CreateContext();

            ProblemSolutions solutions = new ProblemSolutions(softUniContext);

            solutions.EmployeesFullInformation();

            solutions.EmployeesWithSalaryOver50000();

            solutions.EmployeesFromResearchAndDevelopment();

            solutions.AddingNewAddressAndUpdatingEmployee();

            solutions.EmployeesAndProjects();

            solutions.AddressesByTown();

            solutions.Employee147();

            solutions.DepartmentsWithMoreThan5Employees();

            solutions.FindLatest10Projects();

            solutions.IncreaseSalaries();

            solutions.FindEmployeesByFirstNameStartingWith();

            solutions.DeleteProjectById();

            solutions.RemoveTowns();
        }
    }
}

using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data.Models;
using System.Globalization;

namespace P02_DatabaseFirst.Solutions
{
    public class ProblemSolutions
    {
        private SoftUniContext softuniContext;
        private int index = 0;
        private string path = string.Empty;

        public ProblemSolutions(SoftUniContext context)
        {
            this.softuniContext = context;
            this.path = CreatePath();
        }

        //Problem 03
        //Employees Full Information
        public void EmployeesFullInformation()
        {
            var employees = this.softuniContext
                .Employees.Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,

                }).OrderBy(e => e.EmployeeId)
                  .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var e in employees)
                {
                    writer.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
                }
            }
        }

        //Problem 04
        //Employees With Salary Over 50000
        public void EmployeesWithSalaryOver50000()
        {
            var employees = this.softuniContext.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new { e.FirstName })
                .OrderBy(e => e.FirstName)
                .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var e in employees)
                {
                    writer.WriteLine(e.FirstName);
                }
            }
        }

        //Problem 05
        //Employees From Research And Development
        public void EmployeesFromResearchAndDevelopment()
        {
            var employees = this.softuniContext
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary,
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var e in employees)
                {
                    writer.WriteLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:F2}");
                }
            }
        }

        //Problem 06
        //Adding New Address and Updating Employee
        public void AddingNewAddressAndUpdatingEmployee()
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            this.softuniContext.Addresses.Add(newAddress);

            var targetElement = this.softuniContext
                .Employees
                .Include(e => e.Address)
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (targetElement != null)
            {
                targetElement.Address = newAddress;
            }

            this.softuniContext.SaveChanges();

            var employees = this.softuniContext
                .Employees
                .Select(e => new
                {
                    e.Address.AddressText,
                    e.AddressId
                })
                .OrderByDescending(e => e.AddressId)
                .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine(employees[i].AddressText);
                }
            }
        }

        //Problem 07
        //Employees And Projects
        public void EmployeesAndProjects()
        {
            var employees = this.softuniContext.Employees
                .Where
                (
                    e => e.EmployeesProjects.Any
                    (
                        ep => ep.Project.StartDate.Year >= 2001 &&
                        ep.Project.StartDate.Year <= 2003
                    )
                )
                .Select
                (
                    e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects.Select
                        (ep => new
                        {
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                    }
                ).Take(30).ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                string format = $"M/d/yyyy h:mm:ss tt";
                var culture = CultureInfo.InvariantCulture;

                foreach (var e in employees)
                {
                    writer.WriteLine($"{e.Name} - Manager: {e.ManagerName}");

                    foreach (var project in e.Projects)
                    {
                        string startDate = project.StartDate.ToString(format, culture);
                        string endDate = "not finished";

                        if (project.EndDate.HasValue)
                        {
                            endDate = project.EndDate.Value.ToString(format, culture);
                        }

                        writer.WriteLine($"--{project.Name} - {startDate} - {endDate}");
                    }
                }
            }
        }

        //Problem 08
        //Addresses by Town
        public void AddressesByTown()
        {
            var addresses = this.softuniContext
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    CountOfEmployees = a.Employees.Count()
                })
                .OrderByDescending(a => a.CountOfEmployees)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var a in addresses)
                {
                    writer.WriteLine($"{a.AddressText}, {a.TownName} - {a.CountOfEmployees} employees");
                }
            }
        }

        //Problem 09
        //Employee 147
        public void Employee147()
        {
            var employeeProjects = this.softuniContext.Employees
                                                      .Where(ep => ep.EmployeeId == 147)
                                                      .Select
                                                      (
                                                            ep => new
                                                            {
                                                                Name = ep.FirstName + " " + ep.LastName,
                                                                Job = ep.JobTitle,
                                                                Projects = ep.EmployeesProjects
                                                                             .Select
                                                                             (
                                                                                p => new
                                                                                {
                                                                                    p.Project.Name
                                                                                }
                                                                             )
                                                            }
                                                      ).SingleOrDefault();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                writer.WriteLine($"{employeeProjects.Name} - {employeeProjects.Job}");

                foreach (var p in employeeProjects.Projects.OrderBy(pr => pr.Name))
                {
                    writer.WriteLine($"{p.Name}");
                }
            }

        }

        //Problem 10
        //Departments with More Than 5 Employees
        public void DepartmentsWithMoreThan5Employees()
        {
            var departments = this.softuniContext.Departments
                                                 .Where(d => d.Employees.Count > 5)
                                                 .Select
                                                 (
                                                    d => new
                                                    {
                                                        DepName = d.Name,
                                                        ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                                                        Employees = d.Employees.Select
                                                        (
                                                            e => new
                                                            {
                                                                EmpFirstName = e.FirstName,
                                                                EmpLastName = e.LastName,
                                                                EmpJob = e.JobTitle
                                                            }
                                                        )
                                                    }
                                                 ).ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var d in departments.OrderBy(dp => dp.Employees.Count()).ThenBy(dp => dp.DepName))
                {
                    writer.WriteLine($"{d.DepName} - {d.ManagerName}");

                    foreach (var employee in d.Employees.OrderBy(e => e.EmpFirstName).ThenBy(e => e.EmpLastName))
                    {
                        writer.WriteLine($"{employee.EmpFirstName} {employee.EmpLastName} - {employee.EmpJob}");
                    }

                    writer.WriteLine("----------");
                }
            }
        }

        //Problem 11
        //Find Latest 10 Projects
        public void FindLatest10Projects()
        {
            string format = $"M/d/yyyy h:mm:ss tt";
            var culture = CultureInfo.InvariantCulture;

            var latestProjects = this.softuniContext
                                     .Projects
                                     .Select
                                     (
                                        ep => new
                                        {
                                            ProjectName = ep.Name,
                                            ProjectDescription = ep.Description,
                                            ProjectStartDate = ep.StartDate,
                                        }
                                     )
                                     .OrderByDescending(ep => ep.ProjectStartDate)
                                     .Take(10)
                                     .OrderBy(ep => ep.ProjectName)
                                     .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var p in latestProjects)
                {
                    writer.WriteLine($"{p.ProjectName}");
                    writer.WriteLine($"{p.ProjectDescription}");
                    writer.WriteLine($"{p.ProjectStartDate.ToString(format, culture)}");
                }
            }

        }

        //Problem 12
        //Increase Salaries
        public void IncreaseSalaries()
        {
            var employeesForUpdate = this.softuniContext
                                        .Employees
                                        .Where(e => e.Department.Name == "Engineering" ||
                                                    e.Department.Name == "Tool Design" ||
                                                    e.Department.Name == "Marketing" ||
                                                    e.Department.Name == "Information Services")
                                        .OrderBy(e => e.FirstName)
                                        .ThenBy(e => e.LastName)
                                        .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var e in employeesForUpdate)
                {
                    e.Salary *= 1.12m;
                    writer.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
                }
            }

            this.softuniContext.SaveChanges();
        }

        //Problem 13
        //Find Employees by First Name Starting With "Sa"
        public void FindEmployeesByFirstNameStartingWith()
        {
            var employees = this.softuniContext
                                .Employees
                                .Where(e => e.FirstName.StartsWith("Sa"))
                                .Select
                                (
                                    e => new
                                    {
                                        EmpFirstName = e.FirstName,
                                        EmpLastName = e.LastName,
                                        EmpJob = e.JobTitle,
                                        EmpSalary = e.Salary
                                    }
                                )
                                .OrderBy(e => e.EmpFirstName)
                                .ThenBy(e => e.EmpLastName)
                                .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var e in employees)
                {
                    writer.WriteLine($"{e.EmpFirstName} {e.EmpLastName} - {e.EmpJob} - (${e.EmpSalary:F2})");
                }
            }

        }


        //Problem 14
        //Delete Project by Id
        public void DeleteProjectById()
        {
            var project = this.softuniContext.Projects.Find(2);

            var employees = this.softuniContext
                            .EmployeesProjects
                            .Where(e => e.ProjectId == 2)
                            .ToList();

            this.softuniContext.RemoveRange(employees);

            this.softuniContext.Projects.Remove(project);
            this.softuniContext.SaveChanges();

            var projects = this.softuniContext
                               .Projects.Take(10)
                               .ToList();

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                foreach (var p in projects)
                {
                    writer.WriteLine($"{p.Name}");
                }
            }
        }


        //Problem 15
        //Remove Towns
        public void RemoveTowns()
        {
            Console.Write("Please choose town name: ");
            string townName = Console.ReadLine();

            int townId = this.softuniContext
                             .Towns
                             .SingleOrDefault(x => x.Name == townName)
                             .TownId;

            var addressesIDs = this.softuniContext
                                   .Addresses
                                   .Where(a => a.TownId == townId)
                                   .ToList();

            var employees = this.softuniContext
                                .Employees
                                .ToList();

            for (int i = 0; i < addressesIDs.Count; i++)
            {
                for (int j = 0; j < employees.Count; j++)
                {
                    if (addressesIDs[i].AddressId == employees[j].AddressId)
                    {
                        employees[j].AddressId = null;
                    }
                }
            }

            int count = employees.Where(e => e.AddressId == null).Count();

            this.softuniContext.Addresses.RemoveRange(addressesIDs);

            var town = this.softuniContext.Towns.SingleOrDefault(x => x.TownId == townId);

            this.softuniContext.Towns.Remove(town);

            using (var writer = new StreamWriter(this.path + $"\\{index++:D2}.Result.txt"))
            {
                string word = "address";
                if (count > 1)
                {
                    word = "addresses";
                }

                writer.WriteLine($"{count} {word} in {townName} was deleted");
            }

            this.softuniContext.SaveChanges();
        }

        private string CreatePath()
        {
            DirectoryInfo dir = Directory.CreateDirectory($"C:\\Users\\mirom\\OneDrive\\Документи\\Visual Studio 2017\\Projects\\IntroductionToEntityFramework\\P02_DatabaseFirst\\Results");
            return dir.FullName;
        }
    }
}

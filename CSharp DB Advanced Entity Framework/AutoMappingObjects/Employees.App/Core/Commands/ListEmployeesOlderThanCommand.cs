using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public ListEmployeesOlderThanCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int age = int.Parse(args[0]);

            var employees = this.employeeController.ListEmployeesOlderThan(age);

            var sb = new StringBuilder();

            foreach (var listEmployeeDto in employees.OrderByDescending(e => e.Salary))
            {
                string employeeFullName = $"{listEmployeeDto.FirstName} {listEmployeeDto.LastName}";
                string employeeSalary = $"${listEmployeeDto.Salary:F2}";
                string managerName = null;

                if (listEmployeeDto.Manager == null)
                {
                    managerName = "[no manager]";
                }
                else
                {
                    managerName = $"Manager: {listEmployeeDto.Manager.LastName}";
                }

                sb.AppendLine(employeeFullName + " " + " - " + " " + employeeSalary + " " + " - " + " " + managerName);
            }

            return sb.ToString().TrimEnd();
        }
    }
}

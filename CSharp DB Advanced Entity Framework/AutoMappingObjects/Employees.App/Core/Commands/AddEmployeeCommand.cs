using Employees.App.Core.Dtos;
using Employees.App.Core.ExceptionMessages;
using Employees.App.Core.Interfaces;
using Employees.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public AddEmployeeCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            string firstName = args[0];
            string lastname = args[1];
            decimal salary = decimal.Parse(args[2]);

            var employee = new EmployeeDto(firstName, lastname, salary);

            this.employeeController.AddEmployee(employee);

            return $"Employee {employee.FirstName} {employee.LastName} added successfully";
        }
    }
}

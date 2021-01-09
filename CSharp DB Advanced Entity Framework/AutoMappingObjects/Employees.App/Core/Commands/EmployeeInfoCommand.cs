using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeeInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employee = this.employeeController.EmployeeInfo(employeeId);

            return $"ID: {employee.Id} - {employee.FirstName} {employee.LastName} -  ${employee.Salary:F2}";
        }
    }
}

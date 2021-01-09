using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public ManagerInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var manager = this.employeeController.ManagerInfo(employeeId);

            var sb = new StringBuilder();

            string managerInfo = $"{manager.FirstName} {manager.LastName} | Employees: {manager.Employees.Count}";

            sb.AppendLine(managerInfo);

            foreach (var employee in manager.Employees)
            {
                sb.AppendLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

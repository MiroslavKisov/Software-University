using Employees.App.Core.ExceptionMessages;
using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employee = this.employeeController.EmployeePersonalInfo(employeeId);

            var sb = new StringBuilder();

            string personalInfo = $"ID: {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}";

            string birthDay = null;
            string addressInfo = null;

            if (employee.Birthday == null)
            {
                birthDay = Messages.BirthDayInfoDoesNotExist;
            }
            else
            {
                birthDay = $"Birthday {employee.Birthday.Value.Day} - {employee.Birthday.Value.Month} - {employee.Birthday.Value.Year}";
            }

            if (employee.Address == null)
            {
                addressInfo = Messages.AddressInfoDoesNotExist;
            }
            else
            {
                addressInfo = employee.Address;
            }

            sb.AppendLine(personalInfo)
              .AppendLine($"Birthday: {birthDay}")
              .AppendLine($"Address: {addressInfo}");

            return sb.ToString().TrimEnd();
        }
    }
}

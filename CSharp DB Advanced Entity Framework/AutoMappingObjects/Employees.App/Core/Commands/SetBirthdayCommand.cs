using Employees.App.Core.ExceptionMessages;
using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetBirthdayCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            DateTime birthDay = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            this.employeeController.SetBirthday(employeeId, birthDay);

            return Messages.BirthdaySetSuccessfully;
        }
    }
}

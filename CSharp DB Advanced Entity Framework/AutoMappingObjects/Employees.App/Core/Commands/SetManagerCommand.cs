using Employees.App.Core.ExceptionMessages;
using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetManagerCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            this.employeeController.SetManager(employeeId, managerId);

            return Messages.ManagerSetSuccessfully;
        }
    }
}

using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class ExitCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public ExitCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            string exitCommand = args[0].ToLower();

            if (exitCommand == "exit")
            {
                this.employeeController.Exit();
            }

            return "";
        }
    }
}

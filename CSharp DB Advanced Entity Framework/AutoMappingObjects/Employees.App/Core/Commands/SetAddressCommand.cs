using Employees.App.Core.ExceptionMessages;
using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees.App.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetAddressCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            string address = string.Join(" ", args.Skip(1).ToArray());

            this.employeeController.SetAddress(employeeId, address);

            return Messages.AddressSetSuccesfully;
        }
    }
}

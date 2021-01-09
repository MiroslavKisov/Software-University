using Employees.App.Core.ExceptionMessages;
using Employees.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Employees.App.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string ReadCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0] + "Command";
            string[] args = null;

            if (commandName.ToLower() != "exitcommand")
            {
                args = commandArgs.Skip(1).ToArray();
            }
            else
            {
                args = commandArgs.ToArray();
            }

            var type = Assembly.GetCallingAssembly()
                               .GetTypes()
                               .FirstOrDefault(n => n.Name == commandName);

            if (type == null)
            {
                throw new ArgumentException(Messages.InvalidCommand);
            }

            var constructor = type.GetConstructors()
                                  .First();

            var constructorParams = constructor.GetParameters()
                                               .Select(p => p.ParameterType)
                                               .ToArray();

            var service = constructorParams.Select(serviceProvider.GetService)
                                           .ToArray();

            var command = (ICommand)constructor.Invoke(service);

            return command.Execute(args);
        }
    }
}

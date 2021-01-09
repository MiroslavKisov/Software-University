using Employees.App.Core.Interfaces;
using Employees.Services.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core
{
    public class Engine : IEngine
    {
        private IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializeDb = this.serviceProvider.GetService<IDbInitializerService>();
            initializeDb.InitializeDatabase();

            var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine(commandInterpreter.ReadCommand(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

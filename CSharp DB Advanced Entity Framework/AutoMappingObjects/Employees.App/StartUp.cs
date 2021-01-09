using Employees.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Employees.Data.Configurations;
using Employees.Services.Interfaces;
using Employees.Services;
using Employees.App.Core;
using Employees.App.Core.Interfaces;
using Employees.App.Core.Controllers;
using AutoMapper;

namespace Employees.App
{
    public class StartUp
    {
        public static void Main()
        {
            var service = ConfigureService();
            var engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesContext>(options => options.UseSqlServer(ConnectionConfiguration.connection));

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();

            serviceCollection.AddAutoMapper(conf => conf.AddProfile<EmployeesProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}

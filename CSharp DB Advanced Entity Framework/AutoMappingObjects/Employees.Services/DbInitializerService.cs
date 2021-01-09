using Employees.Data;
using Employees.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    public class DbInitializerService : IDbInitializerService
    {
        private readonly EmployeesContext context;

        public DbInitializerService(EmployeesContext employeesContext)
        {
            this.context = employeesContext;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}

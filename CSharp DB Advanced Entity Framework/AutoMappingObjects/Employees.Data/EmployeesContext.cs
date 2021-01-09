using Employees.Data.Configurations;
using Employees.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Employees.Data
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions options) 
            : base(options)
        {
        }

        public EmployeesContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            if (!contextOptionsBuilder.IsConfigured)
            {
                contextOptionsBuilder.UseSqlServer(ConnectionConfiguration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}

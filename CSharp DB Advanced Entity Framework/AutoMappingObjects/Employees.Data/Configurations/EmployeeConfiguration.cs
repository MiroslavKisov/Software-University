using Employees.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.Property(e => e.LastName)
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(50);

            builder.Property(e => e.Address)
                   .IsRequired(false)
                   .IsUnicode(true)
                   .HasMaxLength(100);

            builder.HasOne(e => e.Manager)
                   .WithMany(e => e.Employees)
                   .HasForeignKey(e => e.ManagerId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {

        }

        public EmployeeDto(string firstName, string lastName, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }
    }
}

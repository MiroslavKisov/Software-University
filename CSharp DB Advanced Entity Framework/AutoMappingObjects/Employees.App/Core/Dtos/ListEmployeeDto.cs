using Employees.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Dtos
{
    public class ListEmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public Employee Manager { get; set; }
    }
}

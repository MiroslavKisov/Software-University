using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Dtos
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Employees = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }
    }
}

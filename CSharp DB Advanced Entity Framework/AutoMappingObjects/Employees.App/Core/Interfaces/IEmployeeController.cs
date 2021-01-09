using Employees.App.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Core.Interfaces
{
    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto employeeDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto EmployeeInfo(int employeeId);

        EmployeePersonalInfoDto EmployeePersonalInfo(int employeeId);

        void SetManager(int employeeId, int managerId);

        ManagerDto ManagerInfo(int employeeId);

        ICollection<ListEmployeeDto> ListEmployeesOlderThan (int age);

        void Exit();
    }
}

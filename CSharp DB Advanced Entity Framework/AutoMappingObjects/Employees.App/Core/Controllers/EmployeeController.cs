using AutoMapper;
using AutoMapper.QueryableExtensions;
using Employees.App.Core.Dtos;
using Employees.App.Core.Interfaces;
using Employees.App.Core.ExceptionMessages;
using Employees.Data;
using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees.App.Core.Controllers
{
    public class EmployeeController : IEmployeeController
    {
        private readonly EmployeesContext employeesContext;
        private readonly IMapper mapper;

        public EmployeeController(EmployeesContext employeesContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.employeesContext = employeesContext;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = this.mapper.Map<Employee>(employeeDto);

            this.employeesContext.Add(employee);

            this.employeesContext.SaveChanges();
        }

        public EmployeeDto EmployeeInfo(int employeeId)
        {
            var employee = this.employeesContext
                               .Employees
                               .Find(employeeId);

            var employeeDto = this.mapper.Map<EmployeeDto>(employee);

            if (employeeDto == null)
            {
                throw new ArgumentException(Messages.InvalidId);
            }

            return employeeDto;
        }

        public EmployeePersonalInfoDto EmployeePersonalInfo(int employeeId)
        {
            var employee = this.employeesContext
                               .Employees
                               .Find(employeeId);

            var employeeDto = this.mapper.Map<EmployeePersonalInfoDto>(employee);

            if (employeeDto == null)
            {
                throw new ArgumentException(Messages.InvalidId);
            }

            return employeeDto;
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = this.employeesContext.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(Messages.InvalidId);
            }

            employee.Address = address;
            this.employeesContext.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = this.employeesContext.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(Messages.InvalidId);
            }

            employee.Birthday = date;
            this.employeesContext.SaveChanges();
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.employeesContext.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(Messages.InvalidId);
            }

            var manager = this.employeesContext.Employees.Find(managerId);

            if (manager == null)
            {
                throw new ArgumentException(Messages.InvalidId);
            }

            var employeeDto = this.mapper.Map<EmployeeDto>(employee);

            var managerDto = this.mapper.Map<ManagerDto>(manager);

            employee.Manager = manager;

            managerDto.Employees.Add(employeeDto);

            this.employeesContext.SaveChanges();
        }

        public ManagerDto ManagerInfo(int employeeId)
        {
            var manager = this.employeesContext.Employees.Find(employeeId);

            if (manager == null)
            {
                throw new ArgumentException(Messages.InvalidId);
            }

            var managerDto = this.mapper.Map<ManagerDto>(manager);

            return managerDto;
        }

        public ICollection<ListEmployeeDto> ListEmployeesOlderThan (int age)
        {
            int currentAge = 0;
            int timeNow = DateTime.Now.Year;

            var employees = this.employeesContext
                                .Employees
                                .Where(e => timeNow - e.Birthday.Value.Year > age)
                                .ToList();

            var sb = new StringBuilder();

            ICollection<ListEmployeeDto> resultSetEmployees = new List<ListEmployeeDto>();

            foreach (var employee in employees)
            {
                var listEmployeeDto = this.mapper.Map<ListEmployeeDto>(employee);
                resultSetEmployees.Add(listEmployeeDto);
            }

            return resultSetEmployees;
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}

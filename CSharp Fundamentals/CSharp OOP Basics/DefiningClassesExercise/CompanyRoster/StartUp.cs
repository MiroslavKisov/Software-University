using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var employeesDict = new Dictionary<string, List<Employee>>();
        var departments = new List<string>();
        int numberOfEmployees = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfEmployees; i++)
        {
            string input = Console.ReadLine();
            var currentEmployee = input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (currentEmployee.Length == 4)
            {
                string name = currentEmployee[0];
                decimal salary = decimal.Parse(currentEmployee[1]);
                string position = currentEmployee[2];
                string department = currentEmployee[3];
                Employee employee = new Employee(salary, name, position, department);
                departments.Add(employee.Department);
                AddEmployee(employee, employeesDict);

            }
            else if(currentEmployee.Length == 5)
            {
                bool isInt = int.TryParse(currentEmployee[4], out int ageOut);
                if (isInt)
                {
                    string name = currentEmployee[0];
                    decimal salary = decimal.Parse(currentEmployee[1]);
                    string position = currentEmployee[2];
                    string department = currentEmployee[3];
                    int age = int.Parse(currentEmployee[4]);
                    Employee employee = new Employee(salary, name, position, department, age);
                    departments.Add(employee.Department);
                    AddEmployee(employee, employeesDict);
                }
                else
                {
                    string name = currentEmployee[0];
                    decimal salary = decimal.Parse(currentEmployee[1]);
                    string position = currentEmployee[2];
                    string department = currentEmployee[3];
                    string email = currentEmployee[4];
                    Employee employee = new Employee(salary, name, position, department, email);
                    departments.Add(employee.Department);
                    AddEmployee(employee, employeesDict);
                }
            }
            else
            {
                string name = currentEmployee[0];
                decimal salary = decimal.Parse(currentEmployee[1]);
                string position = currentEmployee[2];
                string department = currentEmployee[3];
                string email = currentEmployee[4];
                int age = int.Parse(currentEmployee[5]);
                Employee employee = new Employee(salary, name, position, department, email, age);
                departments.Add(employee.Department);
                AddEmployee(employee, employeesDict);
            }
        }
        departments = departments.Distinct().ToList();
        var result = new Dictionary<string, decimal>();
        for (int i = 0; i < departments.Count; i++)
        {
            result.Add(departments[i], employeesDict[departments[i]].Select(x => x.Salary).Average());
        }
        var topDepartment = result.FirstOrDefault(x => x.Value == result.Values.Max()).Key;
        Console.WriteLine($"Highest Average Salary: {topDepartment}");
        foreach (var employee in employeesDict[topDepartment].OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }

    private static void AddEmployee(Employee employee, Dictionary<string, List<Employee>> employeesDict)
    {
        if (!employeesDict.ContainsKey(employee.Department))
        {
            employeesDict.Add(employee.Department, new List<Employee>());
            employeesDict[employee.Department].Add(employee);
        }
        else
        {
            employeesDict[employee.Department].Add(employee);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;


class Employee
{
    decimal salary;
    string name;
    string position;
    string department;
    string email;
    int age;
    public decimal Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public string Position
    {
        get { return this.position; }
        set { this.position = value; }
    }
    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }
    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    public Employee(decimal salary, string name, string position, string department, string email, int age)
    {
        this.Salary = salary;
        this.Name = name;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = age;
    }
    public Employee(decimal salary, string name, string position, string department) 
        : this(salary, name, position, department, "n/a")
    {

    }
    public Employee(decimal salary, string name, string position, string department, int age) 
        : this(salary, name, position, department, "n/a", age)
    {

    }
    public Employee(decimal salary, string name, string position, string department, string email) 
        : this(salary, name, position, department, email, -1)
    {

    }
}

